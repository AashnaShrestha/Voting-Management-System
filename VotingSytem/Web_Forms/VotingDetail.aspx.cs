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
    public partial class VotingDetail : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT vd.voter_id, e.employee_name AS Voter_Name, vd.voting_year, vd.voting_month, vd.candidate_id, evd.employee_name AS Candidate_Name FROM employee e JOIN voting_detail vd ON e.employee_id = vd.voter_id JOIN employee evd ON evd.employee_id = vd.candidate_id";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("voting_detail");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            VotingDetailGV.DataSource = dt;
            VotingDetailGV.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string employee = searchTextbox.Text;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT vd.voter_id, e.employee_name AS Voter_Name, vd.voting_year, vd.voting_month, vd.candidate_id, evd.employee_name AS Candidate_Name FROM employee e JOIN voting_detail vd ON e.employee_id = vd.voter_id JOIN employee evd ON evd.employee_id = vd.candidate_id WHERE e.employee_name LIKE '%" + employee + "' OR e.employee_name LIKE '" + employee + "%'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("voting_detail");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();


            VotingDetailGV.DataSource = dt;
            VotingDetailGV.DataBind();
        }
    }
}