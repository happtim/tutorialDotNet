using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Libuv;
using DotNetty.Common.Internal.Logging;
using DotNetty.Buffers;
using DotNetty.Transport.Channels.Groups;
using DotNetty.Handlers.Timeout;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;


namespace Netty
{
    public class Program
    {
        static async Task RunServerAsync()
        {
            ExampleHelper.SetConsoleLogger();

            var STRING_ENCODER = new StringEncoder();
            var STRING_DECODER = new StringDecoder();
            

            var bossGroup = new MultithreadEventLoopGroup(1);
            var workerGroup = new MultithreadEventLoopGroup();
            X509Certificate2 tlsCertificate = null;
            if (ServerSettings.IsSsl)
            {
                tlsCertificate = new X509Certificate2(Path.Combine(ExampleHelper.ProcessDirectory, "dotnetty.com.pfx"), "password");
            }
            try
            {
                var bootstrap = new ServerBootstrap();
                bootstrap
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .Handler(new LoggingHandler("LSTN"))
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        if (tlsCertificate != null)
                        {
                            pipeline.AddLast(TlsHandler.Server(tlsCertificate));
                        }
                        pipeline.AddLast(new LoggingHandler("CONN"));
                        pipeline.AddLast(new IdleStateHandler(10,0,0));
                        pipeline.AddLast(new MyLengthFieldBasedFrameDecoder(ByteOrder.LittleEndian,1024*4,1,4,-5,8,true));
                        pipeline.AddLast(new DelimiterBasedFrameDecoder(1024*4,Unpooled.WrappedBuffer( new byte[] { (byte)'!' } )));
                        pipeline.AddLast(new MyLengthFieldBasedFrameEncoder(), STRING_DECODER, new EchoServerHandler());
                        pipeline.AddLast(new HeartBeatServerHandler());
                    }));

                IChannel bootstrapChannel = await bootstrap.BindAsync(ServerSettings.Port);

                Console.ReadLine();

                await bootstrapChannel.CloseAsync();
            }
            finally
            {
                Task.WaitAll(bossGroup.ShutdownGracefullyAsync(), workerGroup.ShutdownGracefullyAsync());
            }
        }

        public static void Main() => RunServerAsync().Wait();
    }

}
