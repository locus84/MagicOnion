﻿// <auto-generated />
#pragma warning disable CS0618 // 'member' is obsolete: 'text'
#pragma warning disable CS0612 // 'member' is obsolete
#pragma warning disable CS8019 // Unnecessary using directive.

namespace TempProject
{
    using global::System;
    using global::Grpc.Core;
    using global::MagicOnion;
    using global::MagicOnion.Client;
    using global::MessagePack;

    partial class MagicOnionInitializer
    {
        static partial class MagicOnionGeneratedClient
        {
            [global::MagicOnion.Ignore]
            public class TempProject_MyServiceClient : global::MagicOnion.Client.MagicOnionClientBase<global::TempProject.IMyService>, global::TempProject.IMyService
            {
                class ClientCore
                {
                    public global::MagicOnion.Client.Internal.RawMethodInvoker<global::MessagePack.Nil, global::TempProject.MyGenericObject<global::TempProject.MyNestedGenericObject[]>> GetValuesAsync;
                    public ClientCore(global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider)
                    {
                        this.GetValuesAsync = global::MagicOnion.Client.Internal.RawMethodInvoker.Create_ValueType_RefType<global::MessagePack.Nil, global::TempProject.MyGenericObject<global::TempProject.MyNestedGenericObject[]>>(global::Grpc.Core.MethodType.Unary, "IMyService", "GetValuesAsync", serializerProvider);
                    }
                 }

                readonly ClientCore core;

                public TempProject_MyServiceClient(global::MagicOnion.Client.MagicOnionClientOptions options, global::MagicOnion.Serialization.IMagicOnionSerializerProvider serializerProvider) : base(options)
                {
                    this.core = new ClientCore(serializerProvider);
                }

                private TempProject_MyServiceClient(MagicOnionClientOptions options, ClientCore core) : base(options)
                {
                    this.core = core;
                }

                protected override global::MagicOnion.Client.MagicOnionClientBase<global::TempProject.IMyService> Clone(global::MagicOnion.Client.MagicOnionClientOptions options)
                    => new TempProject_MyServiceClient(options, core);

                public global::MagicOnion.UnaryResult<global::TempProject.MyGenericObject<global::TempProject.MyNestedGenericObject[]>> GetValuesAsync()
                    => this.core.GetValuesAsync.InvokeUnary(this, "IMyService/GetValuesAsync", global::MessagePack.Nil.Default);
            }
        }
    }
}
