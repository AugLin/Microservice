using Azure.Messaging.ServiceBus;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;
using System.Text;
using System.Text.Json;

namespace PromotionService
{
    public class QueueService
    {
        private readonly IConfiguration _config;
        public QueueService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendMessageAsync<T>(T model, string queueName)
        {
            var queueCLient = new ServiceBusClient(_config.GetConnectionString("AzureServiceBus"));
            var sender = queueCLient.CreateSender(queueName);
            string messageBody = JsonSerializer.Serialize(model);
            var messageData = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
            await sender.SendMessageAsync(messageData);
        }
    }
}
