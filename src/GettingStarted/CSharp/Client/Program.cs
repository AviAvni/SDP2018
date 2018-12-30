using Grpc.Core;
using SnippetsShared;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:888", ChannelCredentials.Insecure);

            var client = new Snippets.SnippetsClient(channel);

            SnippetResponse reply = await client.SayHelloAsync(new SnippetRequest() { Name = "Avi", Sleep = 1000 });

            Console.WriteLine("Greeting: " + reply.Message);

            await channel.ShutdownAsync();
        }
    }
}
