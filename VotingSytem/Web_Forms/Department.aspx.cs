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
    public partial class Department : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT department_id, department_name FROM Department";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("department");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            DepartmentGV.DataSource = dt;
            DepartmentGV.DataBind();

        }

        protected void CreateDeptBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(deptIdTextbox.Text);
            string name = deptNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into department(department_id, department_name) Values('" + id + "','" + name + "')");
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            deptIdTextbox.Text = "";
            deptNameTextbox.Text = "";

            this.BindGrid();
        }
        protected void UpdateDeptBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(deptIdTextbox.Text);
            string name = deptNameTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("update department set department_name = '" + name + "',department_id = '" + id + "' where department_id = " + id);
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            deptIdTextbox.Text = "";
            deptNameTextbox.Text = "";
            DepartmentGV.EditIndex = -1;

            this.BindGrid();
        }

        protected void DeleteDepartment(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(DepartmentGV.DataKeys[e.RowIndex].Values[0]);
            // string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Department WHERE department_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            DepartmentGV.EditIndex = -1;

        }

        protected void EditDepartment(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            //txtID.Text = this.DepartmentGV.Rows[e.NewEditIndex].Cells[1].Text;
            deptIdTextbox.Text= this.DepartmentGV.Rows[e.NewEditIndex].Cells[1].Text.ToString().TrimStart().TrimEnd();
            deptNameTextbox.Text = this.DepartmentGV.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
        }
    }
}