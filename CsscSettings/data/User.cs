using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    public class User
    {
        private string name = "admin";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string psd = "123456";

        public string Psd
        {
            get { return psd; }
            set { psd = value; }
        }
    }
}
