using Grpc.Core;
using SnippetsShared;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class SnippetsImpl : Snippets.SnippetsBase
    {
        public override async Task<SnippetResponse> SayHello(SnippetRequest request, ServerCallContext context)
        {
            Console.WriteLine("SayHello");
            await Task.Delay(request.Sleep);
            return new SnippetResponse() { Message = "Hello" + request.Name };
        }
    }
}
