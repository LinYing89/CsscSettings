using CsscSettings.data;
using CsscSettings.net;
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
    public partial class FrmSettings : Form
    {
        public static MyClient MY_CLIENT;

        public SynchronizationContext m_SyncContext = null;

        public FrmSettings()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void showFrm(int which)
        {
            if (panelContainer.Controls.Count > 0 && panelContainer.Controls[0] is Form)
            {
                Form frm = (Form)(panelContainer.Controls[0]);
                frm.Close();
            }
            panelContainer.Controls.Clear();
            switch (which)
            {
                case 0:
                    FrmNetSettings frm1 = new FrmNetSettings();
                    frm1.TopLevel = false;
                    frm1.Width = panelContainer.Width - 60;
                    frm1.Height = panelContainer.Height - 60;
                    frm1.Location = new Point(30, 30);
                    panelContainer.Controls.Add(frm1);
                    frm1.Show();
                    labelNetSettings.BackColor = Color.CornflowerBlue;
                    labelNetState.BackColor = Color.Transparent;
                    labelSystemTools.BackColor = Color.Transparent;
                    break;
                case 1:
                    FrmNetState frm2 = new FrmNetState();
                    frm2.TopLevel = false;
                    
                    frm2.Width = panelContainer.Width - 60;
                    frm2.Height = panelContainer.Height - 60;
                    frm2.Location = new Point(30, 30);
                    panelContainer.Controls.Add(frm2);
                    frm2.Show();
                    frm2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                    labelNetSettings.BackColor = Color.Transparent;
                    labelNetState.BackColor = Color.CornflowerBlue;
                    labelSystemTools.BackColor = Color.Transparent;
                    break;
                case 2:
                    FrmSystemTools frm3 = new FrmSystemTools();
                    frm3.TopLevel = false;
                    panelContainer.Controls.Add(frm3);
                    frm3.Show();
                    Point p = new Point((panelContainer.Width - frm3.Width) / 2, (panelContainer.Height - frm3.Height) / 2);
                    frm3.Location = p;
                    labelNetSettings.BackColor = Color.Transparent;
                    labelNetState.BackColor = Color.Transparent;
                    labelSystemTools.BackColor = Color.CornflowerBlue;
                    break;
            }
        }

        private void FrmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            MY_CLIENT.myClose();
            FrmSettings.MY_CLIENT.EventConnectBreak -= MY_CLIENT_EventConnectBreak;
            //initConfig();
            //WriteXml w = new WriteXml();
            //w.Write();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
                if (frmLogin.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }

            timerLink.Enabled = true;
            panelContainer.BackColor = SystemColors.Control;
            showFrm(0);
            FrmSettings.MY_CLIENT.EventConnectBreak += MY_CLIENT_EventConnectBreak;
        }

        bool connectFailIsShow = false;
        private void connectFail(object o)
        {
            connectFailIsShow = true;
            MessageBox.Show("网络连接已断开");
            connectFailIsShow = false;
        }

        void MY_CLIENT_EventConnectBreak(object sender, EventArgs e)
        {
            if (!connectFailIsShow)
            {
                m_SyncContext.Post(connectFail, null);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void labelNetSettings_Click(object sender, EventArgs e)
        {
            showFrm(0);
        }

        private void labelNetState_Click(object sender, EventArgs e)
        {
            showFrm(1);
        }

        private void labelSystemTools_Click(object sender, EventArgs e)
        {
            showFrm(2);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Firebrick;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerLink_Tick(object sender, EventArgs e)
        {
            if (!MY_CLIENT.isConnect())
            {
                MY_CLIENT.link();
            }
        }
        
    }
}
