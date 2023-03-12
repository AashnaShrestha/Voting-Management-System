using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace VotingSytem.Web_Forms
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        string connString = "Data Source=localhost;Persist Security Info=True;User ID=Coursework; Password=coursework;";
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hello");
        }

        protected void CreateEmployeeBtn_Click(object sender, EventArgs e)
        {
            int id = 16;
            string name = employeeNameTextbox.Text;
            System.Diagnostics.Debug.WriteLine(name.Length);
            string date = dateOfBirthTextbox.Text;
            string contact = contactTextbox.Text;

            //string connstr = ConfigurationManager.ConnectionStrings[this.connString].ConnectionString;
            OracleConnection oCon = new OracleConnection(connString);

            // If the Button Says Submit
            // Initializing the Insertion Query
            OracleCommand oCom = new OracleCommand("Insert into employee(employee_id, employee_name, date_of_birth, contact) Values('" + id + "','" + name + "','" + date + "','" + contact + "')");
            System.Diagnostics.Debug.WriteLine(oCom);
           oCom.Connection = oCon;
            oCon.Open();
            oCom.ExecuteNonQuery();
            oCon.Close();

            // Clearing the fields
            employeeNameTextbox.Text = "";
            dateOfBirthTextbox.Text = "";
            contactTextbox.Text = "";
        }


    }
    
}