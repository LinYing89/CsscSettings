using CsscSettings.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsscSettings.forms
{
    public partial class FrmNetSettings : Form
    {
        public SynchronizationContext m_SyncContext = null;

        public FrmNetSettings()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(1, 1);
        }


        public static bool IsValidIP(string ip)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                string[] ips = ip.Split('.');
                if (ips.Length == 4 || ips.Length == 6)
                {
                    if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256 & 
                        System.Int32.Parse(ips[2]) < 256 & System.Int32.Parse(ips[3]) < 256)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private void initWangKaConfig()
        {
            string e1 = cbEthYiDong.SelectedItem.ToString();
            string e2 = cbEthLianTong.SelectedItem.ToString();
            string e3 = cbEthDianXin.SelectedItem.ToString();
            string e4 = cbEthJiaoHuanJi.SelectedItem.ToString();
            if (e1.Equals(e2) || e1.Equals(e3) || e1.Equals(e4)
                || e2.Equals(e3) || e2.Equals(e4)
                || e3.Equals(e4))
            {
                MessageBox.Show("eth有冲突");
                return;
            }

            string ip1 = tbYiDongIp.Text;
            string ip2 = tbLianTongIp.Text;
            string ip3 = tbDianXinIp.Text;
            string ip4 = tbJiaoHuanJiIp.Text;
            if (!IsValidIP(ip1))
            {
                MessageBox.Show("移动VPN地址格式错误");
                return;
            }
            if (!IsValidIP(ip2))
            {
                MessageBox.Show("联通VPN地址格式错误");
                return;
            }
            if (!IsValidIP(ip3))
            {
                MessageBox.Show("电信VPN地址格式错误");
                return;
            }
            if (!IsValidIP(ip4))
            {
                MessageBox.Show("交换机IP地址格式错误");
                return;
            }
            progressBar1.Visible = true;
            Config.Ins.WkYiDong.Ip = ip1;
            Config.Ins.WkLianTong.Ip = ip2;
            Config.Ins.WkDianXin.Ip = ip3;
            Config.Ins.WkJiaoHuanJi.Ip = ip4;
            Config.Ins.WkYiDong.Eth = e1;
            Config.Ins.WkLianTong.Eth = e2;
            Config.Ins.WkDianXin.Eth = e3;
            Config.Ins.WkJiaoHuanJi.Eth = e4;

            List<string> list = new List<string>();
            list.Add("setip_start");
            list.Add(Config.Ins.WkYiDong.Eth + " " + Config.Ins.WkYiDong.Ip);
            list.Add(Config.Ins.WkLianTong.Eth + " " + Config.Ins.WkLianTong.Ip);
            list.Add(Config.Ins.WkDianXin.Eth + " " + Config.Ins.WkDianXin.Ip);
            list.Add(Config.Ins.WkJiaoHuanJi.Eth + " " + Config.Ins.WkJiaoHuanJi.Ip);
            list.Add("setip_end");
            FrmSettings.MY_CLIENT.send(list);
            //FrmSettings.MY_CLIENT.send("setip_start");
            //FrmSettings.MY_CLIENT.send(Config.Ins.WkYiDong.Eth + " " + Config.Ins.WkYiDong.Ip);
            //FrmSettings.MY_CLIENT.send(Config.Ins.WkLianTong.Eth + " " + Config.Ins.WkLianTong.Ip);
            //FrmSettings.MY_CLIENT.send(Config.Ins.WkDianXin.Eth + " " + Config.Ins.WkDianXin.Ip);
            //FrmSettings.MY_CLIENT.send(Config.Ins.WkJiaoHuanJi.Eth + " " + Config.Ins.WkJiaoHuanJi.Ip);
            //FrmSettings.MY_CLIENT.send("setip_end");
            WriteXml w = new WriteXml();
            w.Write();
        }

        private void initLocalSerConfig()
        {
            string ip1 = tbSer1Ip.Text;
            string ip2 = tbSer2Ip.Text;
            string ip3 = tbSer3Ip.Text;
            string ip4 = tbSer4Ip.Text;
            string ip5 = tbSer5Ip.Text;
            string ip6 = tbSer6Ip.Text;
            string ip7 = tbSer7Ip.Text;
            string ip8 = tbSer8Ip.Text;

            if (!string.IsNullOrWhiteSpace(ip1) && !IsValidIP(ip1))
            {
                MessageBox.Show("服务器1 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip2) && !IsValidIP(ip2))
            {
                MessageBox.Show("服务器2 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip3) && !IsValidIP(ip3))
            {
                MessageBox.Show("服务器3 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip4) && !IsValidIP(ip4))
            {
                MessageBox.Show("服务器4 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip5) && !IsValidIP(ip5))
            {
                MessageBox.Show("服务器5 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip6) && !IsValidIP(ip6))
            {
                MessageBox.Show("服务器6 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip7) && !IsValidIP(ip7))
            {
                MessageBox.Show("服务器7 IP地址格式错误");
                return;
            }
            if (!string.IsNullOrWhiteSpace(ip8) && !IsValidIP(ip8))
            {
                MessageBox.Show("服务器8 IP地址格式错误");
                return;
            }

            List<string> list = new List<string>();
            list.Add("dnat_start");

            foreach (LocalSer ls in Config.Ins.ListLocalSer)
            {
                if (ls.Name.Equals("服务器1"))
                {
                    string res = setLocalSer(1, ls, ip1, tbSer1Port.Text, cbSer1ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器2"))
                {
                    string res = setLocalSer(2, ls, ip2, tbSer2Port.Text, cbSer2ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器3"))
                {
                    string res = setLocalSer(3, ls, ip3, tbSer3Port.Text, cbSer3ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器4"))
                {
                    string res = setLocalSer(4, ls, ip4, tbSer4Port.Text, cbSer4ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器5"))
                {
                    string res = setLocalSer(5, ls, ip5, tbSer5Port.Text, cbSer5ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器6"))
                {
                    string res = setLocalSer(6, ls, ip6, tbSer6Port.Text, cbSer6ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器7"))
                {
                    string res = setLocalSer(7, ls, ip7, tbSer7Port.Text, cbSer7ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
                else if (ls.Name.Equals("服务器8"))
                {
                    string res = setLocalSer(8, ls, ip8, tbSer8Port.Text, cbSer8ProtocolType.SelectedItem.ToString());
                    if (null != res)
                    {
                        list.Add(res);
                    }
                }
            }
            if (list.Count <= 2)
            {
                MessageBox.Show("没有可保存数据");
                return;
            }
            progressBar2.Visible = true;
            list.Add("dnat_end");
            FrmSettings.MY_CLIENT.send(list);

            WriteXml w = new WriteXml();
            w.Write();
        }

        private string setLocalSer(int whichSer, LocalSer ls, string ip, string port, string pt)
        {
            try
            {
                ls.Ip = ip;
                if (string.IsNullOrWhiteSpace(port))
                {
                    ls.Port = 0;
                }
                else
                {
                    ls.Port = Convert.ToInt16(port);
                }
                ls.ProtocolType = pt;
                if (!string.IsNullOrWhiteSpace(ls.Ip) && ls.Port != 0)
                {
                    return "server" + whichSer + " " + ls.Ip + " " + ls.Port + " " + ls.ProtocolType;
                    //FrmSettings.MY_CLIENT.send("server" + whichSer + " " + ls.Ip + " " + ls.Port + " " + ls.ProtocolType);
                }
            }
            catch (Exception) { }
            return null;
        }

        private void FrmNetSettings_Load(object sender, EventArgs e)
        {
            tbYiDongIp.Text = Config.Ins.WkYiDong.Ip;
            tbLianTongIp.Text = Config.Ins.WkLianTong.Ip;
            tbDianXinIp.Text = Config.Ins.WkDianXin.Ip;
            tbJiaoHuanJiIp.Text = Config.Ins.WkJiaoHuanJi.Ip;
            cbEthYiDong.SelectedItem = Config.Ins.WkYiDong.Eth;
            cbEthLianTong.SelectedItem = Config.Ins.WkLianTong.Eth;
            cbEthDianXin.SelectedItem = Config.Ins.WkDianXin.Eth;
            cbEthJiaoHuanJi.SelectedItem = Config.Ins.WkJiaoHuanJi.Eth;
            foreach (LocalSer ls in Config.Ins.ListLocalSer)
            {
                if (ls.Name.Equals("服务器1"))
                {
                    tbSer1Ip.Text = ls.Ip;
                    tbSer1Port.Text = ls.Port.ToString();
                    cbSer1ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器2"))
                {
                    tbSer2Ip.Text = ls.Ip;
                    tbSer2Port.Text = ls.Port.ToString();
                    cbSer2ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器3"))
                {
                    tbSer3Ip.Text = ls.Ip;
                    tbSer3Port.Text = ls.Port.ToString();
                    cbSer3ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器4"))
                {
                    tbSer4Ip.Text = ls.Ip;
                    tbSer4Port.Text = ls.Port.ToString();
                    cbSer4ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器5"))
                {
                    tbSer5Ip.Text = ls.Ip;
                    tbSer5Port.Text = ls.Port.ToString();
                    cbSer5ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器6"))
                {
                    tbSer6Ip.Text = ls.Ip;
                    tbSer6Port.Text = ls.Port.ToString();
                    cbSer6ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器7"))
                {
                    tbSer7Ip.Text = ls.Ip;
                    tbSer7Port.Text = ls.Port.ToString();
                    cbSer7ProtocolType.SelectedItem = ls.ProtocolType;
                }
                else if (ls.Name.Equals("服务器8"))
                {
                    tbSer8Ip.Text = ls.Ip;
                    tbSer8Port.Text = ls.Port.ToString();
                    cbSer8ProtocolType.SelectedItem = ls.ProtocolType;
                }
            }

            FrmSettings.MY_CLIENT.EventReceivedOk += MY_CLIENT_EventReceivedOk;
            FrmSettings.MY_CLIENT.EventReceivedError += MY_CLIENT_EventReceivedError;
        }

        private void receivedOk(object o)
        {
            MessageBox.Show("保存成功");
            progressBar1.Visible = false;
            progressBar2.Visible = false;
        }

        private void receivedError(object o)
        {
            MessageBox.Show("保存失败");
            progressBar1.Visible = false;
            progressBar2.Visible = false;
        }

        void MY_CLIENT_EventReceivedError(object sender, EventArgs e)
        {
            m_SyncContext.Post(receivedError, null);
        }

        void MY_CLIENT_EventReceivedOk(object sender, EventArgs e)
        {
            m_SyncContext.Post(receivedOk, null);
        }

        private void btnServerOk_Click(object sender, EventArgs e)
        {
            initLocalSerConfig();
        }

        private void onlyNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表退格，46代表小数点
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
                e.Handled = true;
        }

        private void onlyNumAndDot_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void btnWangKaSave_Click(object sender, EventArgs e)
        {
            initWangKaConfig();
        }

        private void FrmNetSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSettings.MY_CLIENT.EventReceivedOk -= MY_CLIENT_EventReceivedOk;
            FrmSettings.MY_CLIENT.EventReceivedError -= MY_CLIENT_EventReceivedError;
        }
    }
}
