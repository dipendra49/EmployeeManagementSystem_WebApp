using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebApp
{
   
    public partial class CRUD : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dipendra\Documents\BentRayDB.mdf;Integrated Security=True;Connect Timeout=30");

        public void PopulateData()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        {
            if (!IsPostBack)
            {
                string displayQuery = "SELECT * FROM Employee";
                SqlCommand dsplyCmd = new SqlCommand(displayQuery, Conn);
                Conn.Open();
                empGridView.DataSource = dsplyCmd.ExecuteReader();
                empGridView.DataBind();
                Conn.Close();
               
            }

        }
        public void DisplayData()
        {
            string displayQuery = "SELECT * FROM Employee";
            SqlCommand dsplyCmd = new SqlCommand(displayQuery, Conn);
            Conn.Open();
            empGridView.DataSource = dsplyCmd.ExecuteReader();
            empGridView.DataBind();
            Conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateData();
            
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "SELECT COUNT(*) FROM Employee WHERE EmployeeID = "+employeeIDTextBox.Text+"";
                SqlCommand cmd = new SqlCommand(query, Conn);
                //Conn.Open();
                cmd.ExecuteNonQuery();
                //Conn.Close();
                int rows = (int)cmd.ExecuteScalar();
                Conn.Close();
                if (employeeIDTextBox.Text == "" || empNameTextBox.Text == "" || designationTextBox.Text == "" || addressTextBox.Text == "" || salaryTextBox.Text == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Empty field found!', 'Please fill all input field!', 'error')", true);
                }
                else if (rows == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Employee ID already exists!', 'Please insert unique ID!', 'error')", true);
                }
                else
                {
                    Conn.Open();
                    string insertQuery = "INSERT INTO Employee VALUES("+int.Parse(employeeIDTextBox.Text)+", '"+empNameTextBox.Text+"', '"+designationTextBox.Text+"', '"+addressTextBox.Text+"', "+int.Parse(salaryTextBox.Text)+")";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, Conn);
                    //Conn.Open();
                    insertCmd.ExecuteNonQuery();
                    Conn.Close();
                    DisplayData();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Data Added!', 'Data has been added successfully!..', 'success')", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data has been successfully inserted');", true);
                    clearField();
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Inappropraite value has been inserted', 'Please fill appropriate value!', 'error')", true);
                //exceptionMssg.Text = ex.Message;
            }
            //Conn.Close();
        }

        public void clearField()
        {
            employeeIDTextBox.Text = "";
            empNameTextBox.Text = "";
            designationTextBox.Text = "";
            addressTextBox.Text = "";
            salaryTextBox.Text = "";
        }

        protected void clrBtn_Click(object sender, EventArgs e)
        {
            clearField();
        }

        protected void empGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(empGridView.DataKeys[e.RowIndex].Value);
            string dltQuery = "DELETE FROM Employee WHERE EmployeeID = "+id+" ";
            SqlCommand dltCmd = new SqlCommand(dltQuery, Conn);
            Conn.Open();
            int row = dltCmd.ExecuteNonQuery();
            Conn.Close();
            if (row > 0)
            {
                DisplayData();
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Data deleted', 'Data has been successfully deleted!', 'success')", true);

        }

        protected void empGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void empGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            empGridView.EditIndex = e.NewEditIndex;
            DisplayData();
        }

        protected void empGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            empGridView.EditIndex = -1;
            DisplayData();
        }

        protected void empGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(empGridView.DataKeys[e.RowIndex].Value);
            string name = (empGridView.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            string designation = (empGridView.Rows[e.RowIndex].FindControl("txtDesignation") as TextBox).Text;
            string address = (empGridView.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text;
            int salary =Convert.ToInt32((empGridView.Rows[e.RowIndex].FindControl("txtSalary") as TextBox).Text);

            string updQuery = "UPDATE Employee SET Name = '"+name+"', Designation = '"+designation+"', Address = '"+address+"', Salary = "+salary+" WHERE EmployeeID = "+id+" ";
            SqlCommand updCmd = new SqlCommand(updQuery, Conn);
            Conn.Open();
            updCmd.ExecuteNonQuery();
            Conn.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "K", "swal('Data updated', 'Data has been successfully updated!', 'success')", true);
            empGridView.EditIndex = -1;
            DisplayData();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}