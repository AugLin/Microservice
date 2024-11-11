using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqHelper
{
    public class MessageQueue
    {
        private readonly ConnectionFactory factory;
        public MessageQueue(string url, string providerName)
        {
            factory = new ConnectionFactory();
            factory.Uri = new Uri(url);
            factory.ClientProvidedName = providerName;
        }

        public async void AddMessageToQueueAsync(string message, string exchangeName, string queueName, string routingKey)
        {
            IConnection connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.QueueBindAsync(queueName, exchangeName, routingKey);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchangeName, routingKey, messageBodyBytes);
            await channel.CloseAsync();
            await connection.CloseAsync();

            channel.Dispose();
            connection.Dispose();
        }
        public async Task<string> ReadMessageFromQueue(string exchangeName, string queueName, string routingKey)
        {
            IConnection connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.BasicQosAsync(0, 1, false);

            var consumer = new AsyncDefaultBasicConsumer(channel);
            var result = await channel.BasicGetAsync(queueName, true);

            await channel.CloseAsync();
            await connection.CloseAsync();

            channel.Dispose();
            connection.Dispose();
            if (result != null)
            {
                return Encoding.UTF8.GetString(result.Body.ToArray());
            }
            return "No Message Found";
        }
    }
}
