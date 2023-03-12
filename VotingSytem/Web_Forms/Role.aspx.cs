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
    public partial class Role : System.Web.UI.Page
    {
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT role_id, role_name FROM Role";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("role");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            RoleGV.DataSource = dt;
            RoleGV.DataBind();

        }

        protected void CreateRoleBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(roleIdTextbox.Text);
            string name = roleNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into role(role_id, role_name) Values('" + id + "','" + name + "')");
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            roleIdTextbox.Text = "";
            roleNameTextbox.Text = "";

            this.BindGrid();
        }
        protected void UpdateRoleBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(roleIdTextbox.Text);
            string name = roleNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("update role set role_name = '" + name + "',role_id = '" + id + "' where role_id = " + id);
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            roleIdTextbox.Text = "";
            roleNameTextbox.Text = "";
            RoleGV.EditIndex = -1;

            this.BindGrid();
        }

        protected void DeleteRole(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(RoleGV.DataKeys[e.RowIndex].Values[0]);
            // string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Role WHERE role_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            RoleGV.EditIndex = -1;

        }

        protected void EditRole(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            //txtID.Text = this.RoleGV.Rows[e.NewEditIndex].Cells[1].Text;
            roleIdTextbox.Text = this.RoleGV.Rows[e.NewEditIndex].Cells[1].Text.ToString().TrimStart().TrimEnd();
            roleNameTextbox.Text = this.RoleGV.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
        }
    }
}