using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    public class VpnSer
    {
        private string ip = string.Empty;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int port = 7080;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

    }
}
