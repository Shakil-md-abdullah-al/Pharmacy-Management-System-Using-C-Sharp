using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmachyManagementSystem.PharmacistUC
{
    public partial class UC_P_Dashbord : UserControl
    {
        
        public UC_P_Dashbord()
        {
            InitializeComponent();
        }
        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void UC_P_Dashbord_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            txtDate.Text = DateTime.Now.ToLongDateString();
           
            
        }

        private void txtDate_Click(object sender, EventArgs e)
        {

        }
    }
}
