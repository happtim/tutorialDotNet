using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netty
{
    class MyLengthFieldBasedFrameEncoder : MessageToMessageEncoder<string>
    {
        protected override void Encode(IChannelHandlerContext context, string message, List<object> output)
        {
            if (message.Length == 0)
            {
                return;
            }
            // "#" +  length +  "packetid" + message + "!"
            message = "#" + (message.Length +9).ToString().PadLeft(4,'0')  +"999" + message + "!";
            output.Add(ByteBufferUtil.EncodeString(context.Allocator, message, Encoding.UTF8));
        }
    }
}
