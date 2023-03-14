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
    public partial class Employee : System.Web.UI.Page
    {
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        //private string lblErrorMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                updateEmployeeButton.Enabled = false;
                if (!string.IsNullOrEmpty(errorLabel.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#errorModal').modal('show');", true);
                        }
        
                        this.BindGrid();
            }
        }
        private void BindGrid()
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT employee_id, employee_name, date_of_birth, contact FROM Employee";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("employee");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            EmployeeGV.DataSource = dt;
            EmployeeGV.DataBind();

        }

        protected void ShowAddEmployeePage(object sender, EventArgs e)
        {
            Response.Redirect("CreateEmployee.aspx");
        }
        protected void CreateEmployeeBtn_Click(object sender, EventArgs e)
        {
            int id = 16;
            string name = employeeNameTextbox.Text;
            System.Diagnostics.Debug.WriteLine(name.Length);
            string date = dateOfBirthTextbox.Text;
            string contact = contactTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into employee(employee_id, employee_name, date_of_birth, contact) Values('" + id + "','" + name + "','" + date + "','" + contact + "')");
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            employeeNameTextbox.Text = "";
            dateOfBirthTextbox.Text = "";
            contactTextbox.Text = "";

            this.BindGrid();
        }
        protected void UpdateEmployeeBtn_Click(object sender, EventArgs e)
        {
            int id = 16;
            string name = employeeNameTextbox.Text;
            System.Diagnostics.Debug.WriteLine(name.Length);
            string date = dateOfBirthTextbox.Text;
            string contact = contactTextbox.Text;

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("update employee set employee_name = '" + name + "',date_of_birth = '" + date + "',contact = '" + contact + "' where employee_id = " + id);
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            employeeNameTextbox.Text = "";
            dateOfBirthTextbox.Text = "";
            contactTextbox.Text = "";
            updateEmployeeButton.Enabled = false;
            createEmployeeButton.Enabled = true;
            EmployeeGV.EditIndex = -1;

            this.BindGrid();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clearing the fields
            employeeNameTextbox.Text = "";
            dateOfBirthTextbox.Text = "";
            contactTextbox.Text = "";
            updateEmployeeButton.Enabled = false;
            createEmployeeButton.Enabled = true;
            EmployeeGV.EditIndex = -1;
            this.BindGrid();
        }

        protected void DeleteEmployee(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(EmployeeGV.DataKeys[e.RowIndex].Values[0]);
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Employee WHERE employee_id =" + ID))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                this.BindGrid();
                EmployeeGV.EditIndex = -1;
            }
           catch(Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                errorLabel.Text = "The employee could not be deleted.";
                // show the modal using jQuery
                ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "$('#errorModal').modal('show');", true);
            }

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != EmployeeGV.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
            this.BindGrid();
            EmployeeGV.EditIndex = -1;

        }

        protected void EditRecord(object sender, GridViewEditEventArgs e)
        {
            updateEmployeeButton.Enabled = true;
            createEmployeeButton.Enabled = false;
            // get id for data update
            //txtID.Text = this.EmployeeGV.Rows[e.NewEditIndex].Cells[1].Text;
            employeeNameTextbox.Text = this.EmployeeGV.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
            dateOfBirthTextbox.Text = this.EmployeeGV.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd();
            contactTextbox.Text = this.EmployeeGV.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd();
            // (row.Cells[2].Controls[0] as TextBox).Text;
            //txtqual.Text = this.EmployeeGV.Rows[e.NewEditIndex].Cells[4].Text;
            //btnsubmit.Text = "Update";



        }

        
    }
}