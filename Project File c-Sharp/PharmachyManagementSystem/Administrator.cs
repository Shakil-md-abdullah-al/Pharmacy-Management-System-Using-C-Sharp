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
    public partial class Administrator : Form
    {
        String user = " ";
        public Administrator()
        {
            InitializeComponent();
        }

        public string ID
        {
            get { return user.ToString(); }
        }

        public Administrator(String username)
        {
            InitializeComponent();
            userNameLabel.Text = username; 
            user = username;  
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        

        private void DashBoard_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            //Code
            uC_Dashboard1.Visible=false;
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible=false;
            uC_Profile1.Visible = false;
            btnDashbord.PerformClick();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible=true;
            uC_AddUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
    }
}
