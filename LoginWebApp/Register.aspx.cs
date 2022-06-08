using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dipendra\Documents\BentRayDB.mdf;Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void signupBtn_Click1(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "SELECT COUNT(*) FROM Register WHERE Email = '"+emailTextBox.Text+"'";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                int rows = (int)cmd.ExecuteScalar();
                Conn.Close();
                if (emailTextBox.Text == "" || passwordTextBox.Text == "" || conPassTextBox.Text == "")
                {
                    //Response.Write("<script>alert('Please fill all the input field!!')</script>");
                    //labelMessage.Text = "Please fill all the input field!!";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Empty field found!', 'Please fill all input field!..', 'error')", true);
                    passCheckBox.Checked = false;
                }
                else if (rows == 1)
                {
                    //Response.Write("<script>alert('Already have account with this email!!')</script>");
                    //labelMessage.Text = "Already have account with this email!!";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Account already exists!', 'Already have account with this email!..', 'error')", true);
                    passCheckBox.Checked = false;
                }
                else if (!(string.IsNullOrEmpty(emailTextBox.Text)) && passwordTextBox.Text == conPassTextBox.Text)
                {
                    Conn.Open();
                    string queryOne = "INSERT INTO Register VALUES('" + emailTextBox.Text + "', '" + Util.Base64Encode(passwordTextBox.Text) + "')";
                    SqlCommand command = new SqlCommand(queryOne, Conn);
                    command.ExecuteNonQuery();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Registration Completed!', 'Account has been successfully created!..', 'success')", true);
                    //labelMessage.Text = "Data has been successfully added!!";
                    ClearField();
                    Conn.Close();
                }
                 else if (passwordTextBox.Text != conPassTextBox.Text)
                    {
                    //Response.Write("<script>alert('Password is not matching')</script>");
                    //labelMessage.Text = "Password is not matching!!";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Incorrect password!', 'Unmatched password has been entered!..', 'error')", true);
                    passCheckBox.Checked = false;
                }

                else
                {
                    //labelMessage.Text = "Invalid";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Invalid!', 'Please enter appropriate value!..', 'error')", true);
                    passCheckBox.Checked = false;
                }

                    
                
               
            }
            catch
            {
                //Response.Write("<script>alert('Please enter appropriate value')</script>");
                //labelMessage.Text = "Please enter appropriate value!!";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Invalid!', 'Please enter appropriate value!..', 'error')", true);
                passCheckBox.Checked = false;
            }
        }

        //creating a method to clear all the input field
        private void ClearField()
        {
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            conPassTextBox.Text = "";
            passCheckBox.Checked = false;
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        protected void signinBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}