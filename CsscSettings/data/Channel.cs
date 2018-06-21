using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    public class Channel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int strength;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public override string ToString()
        {
            if (null == name)
            {
                return string.Empty;
            }

            return getStrName() + " " + getStrStrength();
        }

        private string getStrName()
        {
            if (name.Equals("mobile"))
            {
                return "中国移动";
            }
            else if (name.Equals("unicom"))
            {
                return "中国联通";
            }
            else
            {
                return "中国电信";
            }
        }

        private string getStrStrength()
        {
            switch (strength)
            {
                case 1:
                    return "弱";
                case 2:
                    return "中";
                case 3:
                    return "强";
            }
            return "";
        }
    }
}
