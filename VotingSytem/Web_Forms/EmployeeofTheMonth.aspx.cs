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
    public partial class EmployeeofTheMonth : System.Web.UI.Page
    {
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                foreach (string month in months)
                {
                    monthDropDown.Items.Add(month);
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
            cmd.CommandText = @"SELECT candidate_id, e.employee_name, votes_count FROM (SELECT candidate_id, COUNT(*) as votes_count FROM voting_detail WHERE voting_year = '2022' AND voting_month = 'January' GROUP BY candidate_id ORDER BY votes_count DESC) JOIN Employee e ON e.employee_id = candidate_id WHERE ROWNUM <= 3";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("voting_detail");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            EmployeeofTheMonthGV.DataSource = dt;
            EmployeeofTheMonthGV.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string year = yearTextbox.Text;
            string month = monthDropDown.Text;
            string employee = yearTextbox.Text;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT candidate_id, e.employee_name, votes_count FROM (SELECT candidate_id, COUNT(*) as votes_count FROM voting_detail WHERE voting_year = '" + year + "' AND voting_month = '" + month + "' GROUP BY candidate_id ORDER BY votes_count DESC) JOIN Employee e ON e.employee_id = candidate_id WHERE ROWNUM <= 3";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("voting_detail");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            EmployeeofTheMonthGV.DataSource = dt;
            EmployeeofTheMonthGV.DataBind();
        }
    }
}