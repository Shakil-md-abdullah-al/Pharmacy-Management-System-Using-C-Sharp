using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PharmachyManagementSystem
{
     class function
    {
        protected SqlConnection getConnection()
            {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-LH6CG7P\\SQLEXPRESS;database=pharmacymanagement; integrated security = True";
            return con;

            }

        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void setData(String query, string msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            con.Open();
            cmd.CommandText= query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
