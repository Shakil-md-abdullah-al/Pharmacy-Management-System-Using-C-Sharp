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
    
    public partial class UC_P_ViewMedicines : UserControl
    {
        function fn = new function();
        string query;

        public UC_P_ViewMedicines()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UC_P_ViewMedicines_Load(object sender, EventArgs e)
        {
            query = "select * from medic";
            setDataGridView(query);
            /* //Alternative of function
            DataSet ds=fn.getData(query);
            guna2DataGridView3.DataSource = ds.Tables[0];*/
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic where mname like '"+txtSearch.Text+"%'";
            setDataGridView(query);

            /* //Alternative of function
             DataSet ds=fn.getData(query);
             guna2DataGridView3.DataSource = ds.Tables[0];*/
        }

        private void setDataGridView(String query)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView3.DataSource = ds.Tables[0];
        }

        string medicineId;
        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineId=guna2DataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
           if(MessageBox.Show("Are You Sure ?","Delete Confirmation !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "delete from medic where mid='"+medicineId+"' ";
                fn.setData(query, "Medicine Recored Deleted.");
                UC_P_ViewMedicines_Load(this, null);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicines_Load(this, null);
        }
    }
}
