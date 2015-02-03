using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Get username and password
            string _username = txtUsername.Text;
            string _password = txtPassword.Text;

            bool loginResult = LoginUser(_username, _password);

            //Check the login result
            if (loginResult)
            {
                //if success
                //Redirect to home page
                Response.Redirect("Default.aspx");
            }
            else
            {
                //if failed
                Response.Write("Login failed.");
            }
        }
        protected bool LoginUser(string username, string pwd)
        {
            bool result = false;

            string connectionString = @"Data Source=optimus-85\sqlexpress;Initial Catalog=Cengea;Persist Security Info=True;User ID=sa;Password=optimus@123";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand comm = new SqlCommand("LoginProcedure", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("username", username);
            comm.Parameters.AddWithValue("password", pwd);

            Object obj = comm.ExecuteScalar();

            if (obj != null)
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    result = true;
                }
            }

            conn.Close();



            return result;
        }
    }
}