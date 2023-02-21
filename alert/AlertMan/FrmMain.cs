using Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AlertMan
{
    public partial class FrmMain : Form
    {
        ScheduleTimer tmAlert;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          DataTable dt =  MysqlService.read_alert();

            string message = dt.Rows[0]["icd"].ToString() + System.Environment.NewLine + dt.Rows[0]["users"].ToString();
            MessageBox.Show(message, "การแจ้งเตือน",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
        }
        private void RunningProcess() 
        {
            DataTable dt = MysqlService.read_alert();
            if (dt.Rows.Count > 0)
            {
                string message = dt.Rows[0]["icd"].ToString() + System.Environment.NewLine + dt.Rows[0]["users"].ToString();
                MessageBox.Show(message, "การแจ้งเตือน",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                MysqlService.update_status(dt.Rows[0]["id"].ToString());
            }

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tmAlert = new ScheduleTimer();
            tmAlert.Elapsed += new ScheduledEventHandler(tmAlert_Elapsed);
            tmAlert.AddEvent(new Schedule.SimpleInterval(DateTime.Now, TimeSpan.FromSeconds(1)));
            tmAlert.Start();
        }

        private void tmAlert_Elapsed(object sender, ScheduledEventArgs e)
        {
            try
            {
                RunningProcess();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmAlert.Stop();
        }
    }
}
