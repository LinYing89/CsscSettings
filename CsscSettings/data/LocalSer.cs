using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    class LocalSer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        private string protocolType = "TCP";

        public string ProtocolType
        {
            get { return protocolType; }
            set { protocolType = value; }
        }

    }
}
