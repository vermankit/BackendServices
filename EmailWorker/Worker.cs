using MassTransit;
using Microsoft.Extensions.Hosting;
using Shared.Message;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmailWorker
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
                await _bus.Publish(new EmailMessage() { Message = "emailAnj=kit=" }, stoppingToken);

                //await Task.Delay(1000, stoppingToken);
           // }
        }
    }


}