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
    public partial class UC_P_AddMedicine : UserControl
    {

        function fn = new function();
        string query;

        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMediID.Text!="" && txtMediName.Text!= "" && txtMediNumber.Text!="" && txtQuantity.Text!="" && txtPricePerUnit.Text!= "")
            {
                string mid = txtMediID.Text;
                String mname =txtMediName.Text;
                string mnumber =txtMediNumber.Text;
                string mdate = txtManufacturingDate.Text;
                string edate =txtExpireDate.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perunit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid,mname,mnumber,mDate,eDate,quantity,perUnit) values('"+mid+ "','" +mname+ "','" +mnumber+ "','" +mdate+ "','" +edate+ "',"+quantity+","+perunit+")";
                fn.setData(query, "Medicine Added Successfully.");
            }
            else
            {
                MessageBox.Show("Enter all Data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMediID.Clear();
            txtMediName.Clear();
            txtQuantity.Clear();
            txtMediNumber.Clear();
            txtPricePerUnit.Clear();
            txtManufacturingDate.ResetText();
            txtExpireDate.ResetText();
        }

        private void UC_P_AddMedicine_Load(object sender, EventArgs e)
        {

        }
    }
}
