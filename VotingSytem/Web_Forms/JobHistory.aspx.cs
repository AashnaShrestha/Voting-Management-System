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
    public partial class JobHistory : System.Web.UI.Page
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
            cmd.CommandText = @"select jh.history_id, e.employee_name, d.department_name, j.job_name, jh.start_date, jh.end_date, jh.end_date-jh.start_date AS Time_Difference FROM Employee e JOIN Job_History jh ON e.employee_id = jh.employee_id JOIN department d ON jh.department_id = d.department_id JOIN job j ON jh.job_id = j.job_id WHERE jh.end_date IS NOT NULL";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("job_history");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            JobHistoryGV.DataSource = dt;
            JobHistoryGV.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string employee = searchTextbox.Text;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select jh.history_id, e.employee_name, d.department_name, j.job_name, jh.start_date, jh.end_date, jh.end_date-jh.start_date AS Time_Difference FROM Employee e JOIN Job_History jh ON e.employee_id = jh.employee_id JOIN department d ON jh.department_id = d.department_id JOIN job j ON jh.job_id = j.job_id WHERE e.employee_name LIKE '%" + employee + "' OR e.employee_name LIKE '" + employee + "%'AND jh.end_date IS NOT NULL";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("job_history");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            JobHistoryGV.DataSource = dt;
            JobHistoryGV.DataBind();
        }
    }
}