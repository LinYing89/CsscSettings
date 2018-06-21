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
    public partial class FrmNetState : Form
    {
        public static List<ChannelState> listChannel = new List<ChannelState>();

        public SynchronizationContext m_SyncContext = null;

        public FrmNetState()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        private void FrmNetState_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Width = dataGridView1.Width / 4 - 2;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 4 - 2;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 4 - 2;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 4;
            timer1.Start();
            initList(null);
            FrmSettings.MY_CLIENT.EventReceivedNetState += MY_CLIENT_EventReceivedNetState;
        }

        void MY_CLIENT_EventReceivedNetState(object sender, EventArgs e)
        {
            m_SyncContext.Post(initList, null);
        }

        private void initList(object o)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < listChannel.Count; i++)
            {
                ChannelState cs = listChannel[i];
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[0].Value = cs.Name;
                if (cs.ChannelMain.Name != null)
                {
                    row.Cells[1].Value = cs.ChannelMain.ToString();
                }
                if (cs.ChannelReserve1.Name != null)
                {
                    row.Cells[2].Value = cs.ChannelReserve1.ToString();
                }
                if (cs.ChannelReserve2.Name != null)
                {
                    row.Cells[3].Value = cs.ChannelReserve2.ToString();
                }
                //dataGridView1.Rows.Add(row);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmSettings.MY_CLIENT.send("status_q");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmSettings.MY_CLIENT.send("status_q");
        }

        private void FrmNetState_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSettings.MY_CLIENT.EventReceivedNetState -= MY_CLIENT_EventReceivedNetState;
            timer1.Stop();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
