using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNetty
{
    public class HeartBeatServerHandler : ChannelHandlerAdapter
    {
        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent) {
                IdleStateEvent e = (IdleStateEvent)evt;
                if (e.State == IdleState.ReaderIdle){
                    context.CloseAsync();
                }
                /*
                else if (e.State == IdleState.WriterIdle)
                {
                    context.WriteAndFlushAsync(new PingMessage());
                }
                */
            }
        }
    }
}
