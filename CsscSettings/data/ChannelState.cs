using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    public class ChannelState
    {
        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Channel channelMain = new Channel();

        public Channel ChannelMain
        {
            get { return channelMain; }
            set { channelMain = value; }
        }
        private Channel channelReserve1 = new Channel();

        public Channel ChannelReserve1
        {
            get { return channelReserve1; }
            set { channelReserve1 = value; }
        }
        private Channel channelReserve2 = new Channel();

        public Channel ChannelReserve2
        {
            get { return channelReserve2; }
            set { channelReserve2 = value; }
        }
    }
}
