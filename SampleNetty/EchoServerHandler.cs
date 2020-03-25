// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace SampleNetty
{
    using System;
    using System.Text;
    using System.Net;
    using DotNetty.Buffers;
    using DotNetty.Transport.Channels;
    using DotNetty.Transport.Channels.Groups;
    using System.Collections.Concurrent;

    public class EchoServerHandler : SimpleChannelInboundHandler<string>
    {
        static volatile IChannelGroup group;

        static ConcurrentDictionary<string, IChannel> sessions = new ConcurrentDictionary<string, IChannel>();

        public override void ChannelActive(IChannelHandlerContext context)
        {
            IChannelGroup g = group;
            if (g == null)
            {
                lock (this)
                {
                    if (group == null)
                    {
                        g = group = new DefaultChannelGroup(context.Executor);
                    }
                }
            }

            g.WriteAndFlushAsync(string.Format("Welcome to {0} secure chat server!\n", Dns.GetHostName()));
            g.Add(context.Channel);

        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            if (sessions.Values.Contains(context.Channel)) {
                foreach (var pair in sessions) {
                    if(pair .Value == context.Channel)
                    {
                        IChannel channel = null;
                        sessions.TryRemove(pair.Key, out channel);
                    }
                }
            }
        }



        protected override void ChannelRead0(IChannelHandlerContext ctx, string msg)
        {
            ctx.WriteAsync(msg);
        }


        public bool SendData(string MAC, string data){

            IChannel channel = null;

            if (sessions.TryGetValue(MAC, out channel))
            {

                channel.WriteAndFlushAsync(data);
                return true;
            }
            return false;
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}