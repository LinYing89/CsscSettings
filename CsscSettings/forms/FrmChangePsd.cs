using CsscSettings.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsscSettings.forms
{
    public partial class FrmChangePsd : Form
    {
        public FrmChangePsd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string oldPsd = tbOldPsd.Text;
            string newPsd = tbNewPsd.Text;
            string newPsdEnsure = tbNewPsdEnsure.Text;
            if (!oldPsd.Equals(Config.Ins.User.Psd))
            {
                MessageBox.Show("原密码错误");
                return;
            }
            if (!newPsd.Equals(newPsdEnsure))
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            Config.Ins.User.Psd = newPsd;
            WriteXml w = new WriteXml();
            w.Write();
            MessageBox.Show("密码修改成功");
            Close();
        }
    }
}
