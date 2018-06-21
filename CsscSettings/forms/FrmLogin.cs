using CsscSettings.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsscSettings.forms
{
    public partial class FrmLogin : Form
    {

        //窗体阴影API
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public SynchronizationContext m_SyncContext = null;

        public FrmLogin()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void labelLogin_MouseEnter(object sender, EventArgs e)
        {
            labelLogin.BackColor = Color.CornflowerBlue;
        }

        private void labelLogin_MouseLeave(object sender, EventArgs e)
        {
            labelLogin.BackColor = Color.SteelBlue;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string psd = tbPsd.Text;
            if (!name.Equals(Config.Ins.User.Name) || !psd.Equals(Config.Ins.User.Psd))
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
