using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud
{
    public partial class login_from : System.Web.UI.Page
    {
        SqlConnection conn=new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            
            
            if(username.Text=="" && password1.Text == "")
            {
                Error1.Visible = true;
                Error2.Visible = true;
                Error1.Text = "Fill the all fildes!";
                Error2.Text = "Fill the all fildes!";
            }
            else 
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from admin where name='" + username.Text + "'", conn);
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string pwd = ds.Tables[0].Rows[0]["pass"].ToString();

                    if(pwd==password1.Text)
                    {
                        Session["user"]= username.Text;
                        Response.Redirect("home.aspx");
                    }
                    else
                    {
                        Error2.Visible = true;
                        Error2.Text = "Your password is incorrect";
                        password1.Text = "";
                    }
                }
                else
                {
                    Error1.Visible = true;
                    Error1.Text = "Your username is incorrect";
                    username.Text = ""; 
                }
            }
        }
    }
            
}