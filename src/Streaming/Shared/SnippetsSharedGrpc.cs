// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SnippetsShared.proto
// </auto-generated>
// Original file comments:
// C#: %UserProfile%\.nuget\packages\Grpc.Tools\1.17.0\tools\windows_x64\protoc.exe --csharp_out . --grpc_out . Snippets.proto --plugin=protoc-gen-grpc=%UserProfile%\.nuget\packages\Grpc.Tools\1.17.0\tools\windows_x64\grpc_csharp_plugin.exe
// Go: protoc snippets.proto --go_out=plugins=grpc:grpc/snippets
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace SnippetsShared {
  /// <summary>
  /// The snippet service definition.
  /// </summary>
  public static partial class Snippets
  {
    static readonly string __ServiceName = "SnippetsShared.Snippets";

    static readonly grpc::Marshaller<global::SnippetsShared.SnippetRequest> __Marshaller_SnippetsShared_SnippetRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnippetsShared.SnippetRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnippetsShared.SnippetResponse> __Marshaller_SnippetsShared_SnippetResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnippetsShared.SnippetResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::SnippetsShared.SnippetRequest, global::SnippetsShared.SnippetResponse> __Method_SayHello = new grpc::Method<global::SnippetsShared.SnippetRequest, global::SnippetsShared.SnippetResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "SayHello",
        __Marshaller_SnippetsShared_SnippetRequest,
        __Marshaller_SnippetsShared_SnippetResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::SnippetsShared.SnippetsSharedReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Snippets</summary>
    public abstract partial class SnippetsBase
    {
      public virtual global::System.Threading.Tasks.Task SayHello(grpc::IAsyncStreamReader<global::SnippetsShared.SnippetRequest> requestStream, grpc::IServerStreamWriter<global::SnippetsShared.SnippetResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Snippets</summary>
    public partial class SnippetsClient : grpc::ClientBase<SnippetsClient>
    {
      /// <summary>Creates a new client for Snippets</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SnippetsClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Snippets that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SnippetsClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SnippetsClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SnippetsClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncDuplexStreamingCall<global::SnippetsShared.SnippetRequest, global::SnippetsShared.SnippetResponse> SayHello(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHello(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::SnippetsShared.SnippetRequest, global::SnippetsShared.SnippetResponse> SayHello(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_SayHello, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SnippetsClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SnippetsClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SnippetsBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello).Build();
    }

    /// <summary>Register service method implementations with a service binder. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SnippetsBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl.SayHello);
    }

  }
}
#endregion
