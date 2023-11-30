using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_Systum
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from admin where name='" + Session["user"] + "'", conn);
            adp.Fill(ds);
            string pass = ds.Tables[0].Rows[0]["pass"].ToString();
            if (Oldpwd.Text != "" && Newpwd.Text != "" && Conpwd.Text != "")
            {


                if (Oldpwd.Text == pass)
                {
                    if (Newpwd.Text == Conpwd.Text)
                    {
                        SqlDataAdapter adp1 = new SqlDataAdapter("Update admin set pass='" + Newpwd.Text + "'", conn);
                        adp1.Fill(ds);
                        string msg = "alert('Your password is successfully changed')";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", msg, true);
                        Oldpwd.Text = "";
                        Newpwd.Text = "";
                        Conpwd.Text = "";
                        err1.Visible = false;
                        err2.Visible = false;
                    }
                    else
                    {
                        err1.Visible = false;
                        err2.Visible = true;
                        err2.Text = "Mismatch in confirm password..!";
                    }
                }
                else
                {
                    err2.Visible = false;
                    err1.Visible = true;
                    err1.Text = "Your Old password is wrong..!";
                }
            }
            else
            {
                err1.Visible = true;
                err2.Visible = true;
                err3.Visible = true;
                err1.Text = "Require to fill this filed";
                err2.Text = "Require to fill this filed";
                err3.Text = "Require to fill this filed";
                
            }
        }
    }
}