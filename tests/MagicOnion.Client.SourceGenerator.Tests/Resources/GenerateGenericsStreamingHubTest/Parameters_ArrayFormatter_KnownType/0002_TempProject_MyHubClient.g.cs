﻿// <auto-generated />
#pragma warning disable

namespace TempProject
{
    partial class MagicOnionInitializer
    {
        static partial class MagicOnionGeneratedClient
        {
            [global::MagicOnion.Ignore]
            public class TempProject_MyHubClient : global::MagicOnion.Client.StreamingHubClientBase<global::TempProject.IMyHub, global::TempProject.IMyHubReceiver>, global::TempProject.IMyHub
            {
                public TempProject_MyHubClient(global::TempProject.IMyHubReceiver receiver, global::Grpc.Core.CallInvoker callInvoker, global::MagicOnion.Client.StreamingHubClientOptions options)
                    : base("IMyHub", receiver, callInvoker, options)
                {
                }

                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetStringValuesAsync(global::System.String[] arg0)
                    => this.WriteMessageWithResponseTaskAsync<global::System.String[], global::MessagePack.Nil>(1774317884, arg0);
                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetIntValuesAsync(global::System.Int32[] arg0)
                    => this.WriteMessageWithResponseTaskAsync<global::System.Int32[], global::MessagePack.Nil>(-400881550, arg0);
                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetInt32ValuesAsync(global::System.Int32[] arg0)
                    => this.WriteMessageWithResponseTaskAsync<global::System.Int32[], global::MessagePack.Nil>(309063297, arg0);
                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetSingleValuesAsync(global::System.Single[] arg0)
                    => this.WriteMessageWithResponseTaskAsync<global::System.Single[], global::MessagePack.Nil>(702446639, arg0);
                public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetBooleanValuesAsync(global::System.Boolean[] arg0)
                    => this.WriteMessageWithResponseTaskAsync<global::System.Boolean[], global::MessagePack.Nil>(2082077357, arg0);

                public global::TempProject.IMyHub FireAndForget()
                    => new FireAndForgetClient(this);

                [global::MagicOnion.Ignore]
                class FireAndForgetClient : global::TempProject.IMyHub
                {
                    readonly TempProject_MyHubClient parent;

                    public FireAndForgetClient(TempProject_MyHubClient parent)
                        => this.parent = parent;

                    public global::TempProject.IMyHub FireAndForget() => this;
                    public global::System.Threading.Tasks.Task DisposeAsync() => throw new global::System.NotSupportedException();
                    public global::System.Threading.Tasks.Task WaitForDisconnect() => throw new global::System.NotSupportedException();

                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetStringValuesAsync(global::System.String[] arg0)
                        => parent.WriteMessageFireAndForgetTaskAsync<global::System.String[], global::MessagePack.Nil>(1774317884, arg0);
                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetIntValuesAsync(global::System.Int32[] arg0)
                        => parent.WriteMessageFireAndForgetTaskAsync<global::System.Int32[], global::MessagePack.Nil>(-400881550, arg0);
                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetInt32ValuesAsync(global::System.Int32[] arg0)
                        => parent.WriteMessageFireAndForgetTaskAsync<global::System.Int32[], global::MessagePack.Nil>(309063297, arg0);
                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetSingleValuesAsync(global::System.Single[] arg0)
                        => parent.WriteMessageFireAndForgetTaskAsync<global::System.Single[], global::MessagePack.Nil>(702446639, arg0);
                    public global::System.Threading.Tasks.Task<global::MessagePack.Nil> GetBooleanValuesAsync(global::System.Boolean[] arg0)
                        => parent.WriteMessageFireAndForgetTaskAsync<global::System.Boolean[], global::MessagePack.Nil>(2082077357, arg0);

                }

                protected override void OnBroadcastEvent(global::System.Int32 methodId, global::System.ReadOnlyMemory<global::System.Byte> data)
                {
                    switch (methodId)
                    {
                    }
                }

                protected override void OnResponseEvent(global::System.Int32 methodId, global::System.Object taskSource, global::System.ReadOnlyMemory<global::System.Byte> data)
                {
                    switch (methodId)
                    {
                        case 1774317884: // Task<Nil> GetStringValuesAsync(global::System.String[] arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskSource, data);
                            break;
                        case -400881550: // Task<Nil> GetIntValuesAsync(global::System.Int32[] arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskSource, data);
                            break;
                        case 309063297: // Task<Nil> GetInt32ValuesAsync(global::System.Int32[] arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskSource, data);
                            break;
                        case 702446639: // Task<Nil> GetSingleValuesAsync(global::System.Single[] arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskSource, data);
                            break;
                        case 2082077357: // Task<Nil> GetBooleanValuesAsync(global::System.Boolean[] arg0)
                            base.SetResultForResponse<global::MessagePack.Nil>(taskSource, data);
                            break;
                    }
                }

                protected override void OnClientResultEvent(global::System.Int32 methodId, global::System.Guid messageId, global::System.ReadOnlyMemory<global::System.Byte> data)
                {
                }
            }
        }
    }
}
