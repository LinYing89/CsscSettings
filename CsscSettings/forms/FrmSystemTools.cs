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
    public partial class FrmSystemTools : Form
    {
        public SynchronizationContext m_SyncContext = null;

        public FrmSystemTools()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            FrmSettings.MY_CLIENT.EventReceivedOk += MY_CLIENT_EventReceivedOk;
            FrmSettings.MY_CLIENT.EventReceivedError += MY_CLIENT_EventReceivedError;
        }

        private void receivedOk(object o)
        {
            MessageBox.Show("恢复成功");
        }

        private void receivedError(object o)
        {
            MessageBox.Show("恢复失败");
        }

        void MY_CLIENT_EventReceivedError(object sender, EventArgs e)
        {
            m_SyncContext.Post(receivedError, null);
        }

        void MY_CLIENT_EventReceivedOk(object sender, EventArgs e)
        {
            m_SyncContext.Post(receivedOk, null);
        }


        private void btnRecovery_Click(object sender, EventArgs e)
        {
            FrmSettings.MY_CLIENT.send("restore");
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            FrmSettings.MY_CLIENT.send("reboot");
        }

        private void btnChangePsd_Click(object sender, EventArgs e)
        {
            FrmChangePsd frm = new FrmChangePsd();
            frm.ShowDialog();
        }

        private void FrmSystemTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSettings.MY_CLIENT.EventReceivedOk -= MY_CLIENT_EventReceivedOk;
            FrmSettings.MY_CLIENT.EventReceivedError -= MY_CLIENT_EventReceivedError;
        }
    }
}
