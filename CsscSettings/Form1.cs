using CsscSettings.data;
using CsscSettings.forms;
using CsscSettings.net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsscSettings
{
    public partial class Form1 : Form
    {

        //窗体阴影API
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public SynchronizationContext m_SyncContext = null;

        public Form1()
        {
            InitializeComponent();

            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);

            if (!File.Exists(WriteXml.CONFIG_FILE))
            {
                File.Create(WriteXml.CONFIG_FILE);
            }
            ReadXml r = new ReadXml();
            r.readConfig();

            m_SyncContext = SynchronizationContext.Current;

            FrmSettings.MY_CLIENT = new MyClient();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Config.Ins.VpnSer.Ip = tbIp.Text;
            Config.Ins.VpnSer.Port = Convert.ToInt32(tbPort.Text);

            if (String.IsNullOrEmpty(Config.Ins.VpnSer.Ip))
            {
                MessageBox.Show("ip地址不可为空");
                return;
            }
            if (Config.Ins.VpnSer.Port <= 0 || Config.Ins.VpnSer.Port > 65535)
            {
                MessageBox.Show("端口号不正确");
                return;
            }

            labelConnect.Enabled = false;

            FrmSettings.MY_CLIENT.link();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbIp.Text = Config.Ins.VpnSer.Ip;
            tbPort.Text = Config.Ins.VpnSer.Port.ToString();
            FrmSettings.MY_CLIENT.EventConnectOk += MY_CLIENT_EventConnectOk;
            FrmSettings.MY_CLIENT.EventConnectFail += MY_CLIENT_EventConnectFail;
        }

        void MY_CLIENT_EventConnectFail(object sender, EventArgs e)
        {
            m_SyncContext.Post(connectFail, null);
        }

        void MY_CLIENT_EventConnectOk(object sender, EventArgs e)
        {
            m_SyncContext.Post(connectOk, null);
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

        private void connectOk(object o)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void connectFail(object o)
        {
            labelServerInfoError.Visible = true;
            labelConnect.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Firebrick;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void labelConnect_MouseEnter(object sender, EventArgs e)
        {
            labelConnect.BackColor = Color.CornflowerBlue;
        }

        private void labelConnect_MouseLeave(object sender, EventArgs e)
        {
            labelConnect.BackColor = Color.SteelBlue;
        }

        private void labelConnect_Click(object sender, EventArgs e)
        {
            Config.Ins.VpnSer.Ip = tbIp.Text;
            Config.Ins.VpnSer.Port = Convert.ToInt32(tbPort.Text);

            if (String.IsNullOrEmpty(Config.Ins.VpnSer.Ip))
            {
                MessageBox.Show("ip地址不可为空");
                return;
            }
            if (Config.Ins.VpnSer.Port <= 0 || Config.Ins.VpnSer.Port > 65535)
            {
                MessageBox.Show("端口号不正确");
                return;
            }

            labelConnect.Enabled = false;

            FrmSettings.MY_CLIENT.link();
        }
    }
}
