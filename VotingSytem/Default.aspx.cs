using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VotingSytem.Webforms;

namespace VotingSytem
{
    public partial class _Default : Page
    {
        private string constr = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT count(*) FROM employee";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("employee");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            employeeLabel.Text = dt.Rows[0][0].ToString();

            cmd.CommandText = @"SELECT count(*) FROM department";
            cmd.CommandType = CommandType.Text;

            DataTable dt1 = new DataTable("department");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt1.Load(sdr);
            }
            departmentLabel.Text = dt1.Rows[0][0].ToString();

            cmd.CommandText = @"SELECT count(*) FROM job";
            cmd.CommandType = CommandType.Text;

            DataTable dt2 = new DataTable("job");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt2.Load(sdr);
            }
            jobLabel.Text = dt2.Rows[0][0].ToString();

            cmd.CommandText = @"SELECT count(*) FROM role";
            cmd.CommandType = CommandType.Text;

            DataTable dt3 = new DataTable("role");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt3.Load(sdr);
            }
            roleLabel.Text = dt3.Rows[0][0].ToString();
            con.Close();


        }
    }
    }
