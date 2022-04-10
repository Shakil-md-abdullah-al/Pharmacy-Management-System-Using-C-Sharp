using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmachyManagementSystem
{
    public partial class SplashFrom : Form
    {
        public SplashFrom()
        {
            InitializeComponent();
        }

        private void SplashFrom_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 5;
            progress.Value = startpoint;
            if(progress.Value ==100)
            {
                progress.Value = 0;
                timer1.Stop();
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
