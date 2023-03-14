using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VotingSytem.Webforms
{
    public partial class Job : System.Web.UI.Page
    {
        Dictionary<string, int> rolesDict = new Dictionary<string, int>();
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                updateJobButton.Enabled = false;
                this.BindGrid();
                this.GetRoles();
            }
        }

        private void GetRoles()
        {
            string query = "SELECT * FROM Role"; // Replace with your SQL query to retrieve the roles

            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem
                        {
                            Text = reader["role_name"].ToString(),
                            Value = reader["role_id"].ToString()
                        };
                        RoleDropDown.Items.Add(item);
                    }

                    reader.Close();

                }
            }


        }

        private void BindGrid()
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT j.job_id, j.job_name, r.role_name FROM Job j JOIN Role r ON j.role_id = r.role_id";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("job");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            JobGV.DataSource = dt;
            JobGV.DataBind();

        }

        protected void CreateJobBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(jobIdTextbox.Text);
            string name = jobNameTextbox.Text;
            int role = Int32.Parse(RoleDropDown.Text);

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into job(job_id, job_name, role_id) Values('" + id + "','" + name + "','" + role + "')");
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            jobIdTextbox.Text = "";
            jobNameTextbox.Text = "";

            this.BindGrid();
        }
        protected void UpdateJobBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(jobIdTextbox.Text);
            string name = jobNameTextbox.Text;
            int role = Int32.Parse(RoleDropDown.Text);

            OracleConnection oCon = new OracleConnection(constr);

            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("update job set job_name = '" + name + "',job_id = '" + id + "',role_id = '" + role + "' where job_id = " + id);
            System.Diagnostics.Debug.WriteLine(oCom);
            oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            jobIdTextbox.Text = "";
            jobNameTextbox.Text = "";
            updateJobButton.Enabled = false;
            createJobButton.Enabled = true;
            JobGV.EditIndex = -1;

            this.BindGrid();
        }

        protected void DeleteJob(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(JobGV.DataKeys[e.RowIndex].Values[0]);
            // string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Job WHERE job_id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            JobGV.EditIndex = -1;

        }

        protected void EditJob(object sender, GridViewEditEventArgs e)
        {
            updateJobButton.Enabled = true;
            createJobButton.Enabled = false;
            // get id for data update
            //txtID.Text = this.JobGV.Rows[e.NewEditIndex].Cells[1].Text;
            jobIdTextbox.Text = this.JobGV.Rows[e.NewEditIndex].Cells[1].Text.ToString().TrimStart().TrimEnd();
            jobNameTextbox.Text = this.JobGV.Rows[e.NewEditIndex].Cells[2].Text.ToString().TrimStart().TrimEnd();
        }
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clearing the fields
            jobIdTextbox.Text = "";
            jobNameTextbox.Text = "";
            updateJobButton.Enabled = false;
            createJobButton.Enabled = true;
            JobGV.EditIndex = -1;

            this.BindGrid();
        }
    }
}