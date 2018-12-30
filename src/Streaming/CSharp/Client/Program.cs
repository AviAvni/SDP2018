using Grpc.Core;
using SnippetsShared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:888", ChannelCredentials.Insecure);

            var client = new Snippets.SnippetsClient(channel);

            AsyncDuplexStreamingCall<SnippetRequest, SnippetResponse> stream = client.SayHello();
            for (int i = 0; i < 10; i++)
            {
                await stream.RequestStream.WriteAsync(new SnippetRequest() { Sleep = 1000, Name = i.ToString() });
            }

            await stream.RequestStream.CompleteAsync();

            await Task.Delay(5000);

            var cts = new CancellationTokenSource();
            while (await stream.ResponseStream.MoveNext(cts.Token))
            {
                Console.WriteLine(stream.ResponseStream.Current.Message);
            }

            await channel.ShutdownAsync();
        }
    }
}
