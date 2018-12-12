using Grpc.Core;
using SnippetsShared;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class SnippetsImpl : Snippets.SnippetsBase
    {
        public override async Task SayHello(IAsyncStreamReader<SnippetRequest> requestStream, IServerStreamWriter<SnippetResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                Console.WriteLine(requestStream.Current.Name);
                await Task.Delay(requestStream.Current.Sleep);
                await responseStream.WriteAsync(new SnippetResponse() { Message = "Hello from C# to: " + requestStream.Current.Name });
            }
        }
    }
}
