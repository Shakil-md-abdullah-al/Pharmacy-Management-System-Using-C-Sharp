using DGVPrinterHelper;
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
    public partial class UC_P_SellMedicine : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;


        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {
            listBoxMedicines.Items.Clear();
            query = "select mname from medic where quantity > '0'";
            ds = fn.getData(query);

            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }


        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SellMedicine_Load(this, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxMedicines.Items.Clear ();
            query = "select mname from medic where mname like '"+txtSearch.Text+"%'and quantity > '0'";
            ds = fn.getData(query);

            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBoxMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoOfUnits.Clear();

            String name=listBoxMedicines.GetItemText(listBoxMedicines.SelectedItem);

            txtMediName.Text = name;
            query = "select mid,eDate,perUnit from medic where mname='"+name+"'";
            ds=fn.getData(query);

            txtMediId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExpireDate.Text= ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text= ds.Tables[0].Rows[0][2].ToString();
           
        }

        private void txtNoOfUnits_TextChanged(object sender, EventArgs e)
        {
            if(txtNoOfUnits.Text != "")
            {
                Int64 unitPrice =Int64.Parse(txtPricePerUnit.Text);
                Int64 noOfUnit = Int64.Parse(txtNoOfUnits.Text);
                Int64 totalAmount = unitPrice * noOfUnit;
                txtTotalPrice.Text = totalAmount.ToString();
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }


        protected int n,totalAmount=0;
        protected Int64 quantity, newQuantity;

       

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if(txtMediId.Text !="")
            {
                query = "select quantity from medic where mid='"+txtMediId.Text+"'";
                ds =fn.getData(query);

                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(txtNoOfUnits.Text);

                if(newQuantity >= 0)
                {
                    n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMediId.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMediName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value =txtExpireDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value =txtPricePerUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtNoOfUnits.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value =txtTotalPrice.Text;


                    //Calculate Total Amount
                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);

                    //Show In Gride
                    totalLabel.Text = "Tk." + totalAmount.ToString();

                    //Substruct the same value from Database
                    query = "update medic set quantity ='"+newQuantity+"' where mid ='"+txtMediId.Text+"'";
                    fn.setData(query, "Medicine Added.");

                }
                else
                {
                    MessageBox.Show("Medicine is Out of Stock. \n Only "+quantity+"Left","Warning !!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                clearAll();
                UC_P_SellMedicine_Load(this,null);
            }
            else
            {
                MessageBox.Show("Select Medicine First.", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }


        int valueAmount;
        String valueId;
        protected Int64 noOfunit;

        

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfunit =Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(valueId != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query = "select quantity from medic where mid ='"+valueId+"'";
                    ds=fn.getData(query);
                    quantity =Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfunit;

                    query = "update medic set quantity ='"+newQuantity+"' where mid='"+valueId+"'";
                    fn.setData(query, "Medicine Removed from Cart.");
                    totalAmount = totalAmount - valueAmount;

                    totalLabel.Text = "TK."+totalAmount.ToString();
                }
                UC_P_SellMedicine_Load(this, null);
            }
        }

        

        private void btnPurchasePrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Medicine Bill";
            print.SubTitle=String.Format("Date:- {0}", DateTime.Now.ToLongDateString());
           // print.SubTitle = String.Format("Time:- {0}", DateTime.Now.ToLongTimeString());
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount :" + totalLabel.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);

            totalAmount = 0;
            totalLabel.Text = "Tk. 00";
            guna2DataGridView1.DataSource = 0;


        }

        //Clear All Data from the Text Box
        private void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtExpireDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnits.Clear();

        }
    }
}
