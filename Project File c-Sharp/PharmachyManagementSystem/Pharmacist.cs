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
    public partial class Pharmacist : Form
    {
        function fn = new function();
        string query;


        public Pharmacist()
        {
            InitializeComponent();
        }

        public Pharmacist(String user)
        {
            InitializeComponent();
            txtusernameP.Text = user;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
        private void Pharmacist_Load(object sender, EventArgs e)
        {
            uC_P_Dashbord1.Visible = false;
            uC_P_AddMedicine1.Visible = false;
            uC_P_ViewMedicines1.Visible = false;
            uC_P_UpdateMedicine1.Visible = false;
            uC_P_SellMedicine1.Visible = false;
            btnDashbord.PerformClick();

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_P_Dashbord1.Visible = true;
             uC_P_Dashbord1.BringToFront();
           
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_P_AddMedicine1.Visible = true;
            uC_P_AddMedicine1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicines1.Visible = true;
            uC_P_ViewMedicines1.BringToFront();
        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uC_P_UpdateMedicine1.Visible=true;
            uC_P_UpdateMedicine1.BringToFront();
        }

       

        private void uC_P_UpdateMedicine1_Load(object sender, EventArgs e)
        {

        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uC_P_SellMedicine1.Visible=true;
            uC_P_SellMedicine1.BringToFront();
        }

        private void uC_P_SellMedicine1_Load(object sender, EventArgs e)
        {

        }
    }
}
