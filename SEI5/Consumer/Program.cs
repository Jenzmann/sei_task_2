using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "SEI5", durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine("Consumer started");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received message: {message}");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("SEI5", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        static async Task publish(string message, IChannel channel)
        {
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(string.Empty, "SEI5", body);
        }
    }
}
