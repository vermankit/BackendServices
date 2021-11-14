using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Message;

namespace EmailWorker
{
    public class MessageConsumer :
        IConsumer<EmailMessage>
    {
        readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<EmailMessage> context)
        {
            _logger.LogInformation("Received Text: {Text}", JsonConvert.SerializeObject(context.Message));

            return Task.CompletedTask;
        }
    }
}
