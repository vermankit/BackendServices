using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;

namespace EmailWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(config =>
                    {
                        config.AddConsumer<MessageConsumer>();
                        config.UsingRabbitMq((ctx, cfg) =>
                        {
                            cfg.ReceiveEndpoint(BusConstants.NotificationQueue, c =>
                            {
                                c.ConfigureConsumer<MessageConsumer>(ctx);
                            });
                        });
                    });
                    services.AddMassTransitHostedService(true);
                    services.AddHostedService<Worker>();
                });
    }
}
