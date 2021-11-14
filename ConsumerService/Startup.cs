using ConsumerService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Shared.Clients;
using Shared.Clients.Interface;
using Steeltoe.Discovery.Client;
using System;
using System.Net.Http;
using AutoMapper;
using ConsumerService.Mapper;
using ConsumerService.Repositories.Interface;

namespace ConsumerService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient<IConsumerClient, ConsumerClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Application:BookingProvider"]);
            }).AddPolicyHandler(GetRetryPolicy()).AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IPartnerClient, PartnerClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Application:PartnerProvider"]);
            }).AddPolicyHandler(GetRetryPolicy()).AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<INotificationClient, NotificationClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Application:NotificationProvider"]);
            }).AddPolicyHandler(GetRetryPolicy()).AddPolicyHandler(GetCircuitBreakerPolicy());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConsumerService", Version = "v1" });
            });
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddDiscoveryClient(Configuration);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsumerService v1"));
            }

            app.UseDiscoveryClient();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()  //Many faults are transient and may self-correct after a short delay Like 404 
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(2));
        }
        private IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));  //Http5XX HTTP408 Request timeout
        }
    }
}