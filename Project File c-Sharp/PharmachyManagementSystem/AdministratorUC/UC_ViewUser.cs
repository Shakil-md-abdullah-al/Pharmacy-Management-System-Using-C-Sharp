using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmachyManagementSystem.AdministratorUC
{
    public partial class UC_ViewUser : UserControl
    {

        function fn = new function();
        String query;
        String currentUser = "";

        public UC_ViewUser()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { currentUser = value; }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            DataSet ds = fn.getData(query);
            guna2DataGridView3.DataSource = ds.Tables[0];



        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '" + txtUserName.Text +"%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView3.DataSource=ds.Tables[0];

        }

        String userName;
        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = guna2DataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();

            }
            catch 
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {



                if (currentUser != userName)
                {
                    query = "delete from users where userName = '" + userName + "'";
                    fn.setData(query, "User Record Deleted.");
                    UC_ViewUser_Load(this, null);
                }
                else
                {
                    MessageBox.Show("You are Trying to delete \n Your Own Profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }
    }
}
