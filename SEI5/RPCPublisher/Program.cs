using System.Threading.Channels;

namespace RPCPublisher
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var rpcClient = new RpcClient();
            await rpcClient.StartAsync();

            Console.WriteLine("Publisher started");
            while (true)
            {
                Console.WriteLine("Type message to be sent to consumer: ");
                var input = Console.ReadLine();

                Console.WriteLine("Publishing message to consumer");
                var response = await rpcClient.CallAsync(input ?? "");
                Console.WriteLine("Response: " + response);

                Console.WriteLine("Message sent successfully!");
            }

            
        }
    }
}
