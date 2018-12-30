using Grpc.Core;
using SnippetsShared;
using System;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace Server
{

    class Program
    {
        const int Port = 888;

        static async Task Main(string[] args)
        {
            var server = new Grpc.Core.Server
            {
                Services = { Snippets.BindService(new SnippetsImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Server is up and running...");

            var tcs = new TaskCompletionSource<bool>();

            AssemblyLoadContext.Default.Unloading += c => tcs.SetResult(true);

            await tcs.Task;

            await server.ShutdownAsync();
        }
    }
}
