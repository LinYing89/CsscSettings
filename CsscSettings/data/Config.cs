using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsscSettings.data
{
    public class Config
    {

        private static Config ins = new Config();

        public static Config Ins
        {
            get { return Config.ins; }
            set { Config.ins = value; }
        }

        private Config()
        {
            wkYiDong.Eth = "eth0";
            wkLianTong.Eth = "eth0";
            wkDianXin.Eth = "eth0";
            wkJiaoHuanJi.Eth = "eth0";
            for (int i = 1; i <= 8; i++)
            {
                LocalSer l = new LocalSer();
                l.Name = "服务器" + i;
                listLocalSer.Add(l);
                l.ProtocolType = "TCP";
            }
        }



        private User user = new User();

        public User User
        {
            get { return user; }
            set { user = value; }
        }
        private VpnSer vpnSer = new VpnSer();

        public VpnSer VpnSer
        {
            get { return vpnSer; }
            set { vpnSer = value; }
        }

        private WangKa wkYiDong = new WangKa();

        internal WangKa WkYiDong
        {
            get { return wkYiDong; }
            set { wkYiDong = value; }
        }
        private WangKa wkLianTong = new WangKa();

        internal WangKa WkLianTong
        {
            get { return wkLianTong; }
            set { wkLianTong = value; }
        }
        private WangKa wkDianXin = new WangKa();

        internal WangKa WkDianXin
        {
            get { return wkDianXin; }
            set { wkDianXin = value; }
        }

        private WangKa wkJiaoHuanJi = new WangKa();

        internal WangKa WkJiaoHuanJi
        {
            get { return wkJiaoHuanJi; }
            set { wkJiaoHuanJi = value; }
        }


        private List<LocalSer> listLocalSer = new List<LocalSer>();

        internal List<LocalSer> ListLocalSer
        {
            get { return listLocalSer; }
            set { listLocalSer = value; }
        }

    }
}
