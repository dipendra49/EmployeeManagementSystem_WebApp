using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dipendra\Documents\BentRayDB.mdf;Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
                {
                    emailTextBoxLogin.Text = Request.Cookies["Email"].Value;
                    passwordTextBoxLogin.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void signinBtnLogin_Click(object sender, EventArgs e)
        {
            //Remember me functionality 
            if (chkRememberMe.Checked)
            {
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["Email"].Value = emailTextBoxLogin.Text.Trim();
            Response.Cookies["Password"].Value = passwordTextBoxLogin.Text.Trim();
            //Response.Redirect("CRUD.aspx");
            try
            {
                //var value = Util.Base64Decode("SELECT Password FROM Register WHERE Email = '"+emailTextBoxLogin.Text+"' ");
                //SqlCommand dataCmd = new SqlCommand(value, Conn);
                //dataCmd.ExecuteNonQuery();
                //Conn.Close();
                //Conn.Open();
                Conn.Open();
                string loginQuery = "SELECT COUNT(*) FROM Register WHERE Email = '"+emailTextBoxLogin.Text+"' AND Password = '" +Util.Base64Encode(passwordTextBoxLogin.Text)+"' ";
                SqlCommand cmd = new SqlCommand(loginQuery, Conn);
                
                cmd.ExecuteNonQuery();
                int rows = (int)cmd.ExecuteScalar();
                Conn.Close();
                if (rows == 1)
                {
                    //To redirect user to next page when the username and password matches, do the following things
                    //Response.Redirect("CRUD.aspx"); OR
                    Server.Transfer("CRUD.aspx");
                }
                else if (emailTextBoxLogin.Text == "" || passwordTextBoxLogin.Text == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Empty field found!', 'Please fill all input field!', 'error')", true);
                    passCheckBox.Checked = false;
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Email or password is wrong!', 'Please fill correct email or password!', 'error')", true);
                    passCheckBox.Checked = false;
                }
            }
            catch(Exception ex)
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Invalid!', 'Please enter appropriate value!', 'error')", true);
                label1.Text = ex.Message;
                passCheckBox.Checked = false;
            }
            //Conn.Close();
        }

        protected void signupBtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void clearBtnLogin_Click(object sender, EventArgs e)
        {
            emailTextBoxLogin.Text = "";
            passwordTextBoxLogin.Text = "";
            passCheckBox.Checked = false;
        }
    }
}