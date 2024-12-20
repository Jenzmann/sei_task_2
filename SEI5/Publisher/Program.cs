using RabbitMQ.Client;
using System.Text;

namespace Publisher
{
    //docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4.0-management
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();


            await channel.QueueDeclareAsync(queue: "SEI5", durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine("Publisher started");
            while (true)
            {
                Console.WriteLine("Type message to be sent to consumer: ");
                var input = Console.ReadLine();

                Console.WriteLine("Publishing message to consumer");
                await publish(input ?? "", channel);

                Console.WriteLine("Message sent successfully!");
            }
        }

        static async Task publish(string message, IChannel channel)
        {
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(string.Empty, "SEI5", body);
        }
    }
}
