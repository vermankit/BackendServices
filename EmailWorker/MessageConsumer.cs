using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Message;
using System.Threading.Tasks;

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
