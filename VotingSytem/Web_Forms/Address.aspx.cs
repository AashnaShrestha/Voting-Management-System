using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VotingSytem.Webforms
{
    public partial class Address : System.Web.UI.Page
    {
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                updateAddressButton.Enabled = false;
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT address_id, address_name FROM Address";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("address");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            AddressGV.DataSource = dt;
            AddressGV.DataBind();

        }

        protected void CreateAddressBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(addressIdTextbox.Text);
            string name = addressNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into address(address_id, address_name) Values('" + id + "','" + name + "')");
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            addressIdTextbox.Text = "";
            addressNameTextbox.Text = "";

            this.BindGrid();
        }
        protected void UpdateAddressBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(addressIdTextbox.Text);
            string name = addressNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("update address set address_name = '" + name + "',address_id = '" + id + "' where address_id = " + id);
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            addressIdTextbox.Text = "";
            addressNameTextbox.Text = "";
            updateAddressButton.Enabled = false;
            createAddressButton.Enabled = true;
            AddressGV.EditIndex = -1;

            this.BindGrid();
        }

        protected void DeleteAddress(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(AddressGV.DataKeys[e.RowIndex].Values[0]);
            // string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Address WHERE address_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            AddressGV.EditIndex = -1;

        }

        protected void EditAddress(object sender, GridViewEditEventArgs e)
        {
            updateAddressButton.Enabled = true;
            createAddressButton.Enabled = false;
            // get id for data update
            //txtID.Text = this.AddressGV.Rows[e.NewEditIndex].Cells[1].Text;
            addressIdTextbox.Text = this.AddressGV.Rows[e.NewEditIndex].Cells[1].Text.ToString().TrimStart().TrimEnd();
            addressNameTextbox.Text = this.AddressGV.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
        }
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clearing the fields
            addressIdTextbox.Text = "";
            addressNameTextbox.Text = "";
            updateAddressButton.Enabled = false;
            createAddressButton.Enabled = true;
            AddressGV.EditIndex = -1;

            this.BindGrid();
        }
    }
}