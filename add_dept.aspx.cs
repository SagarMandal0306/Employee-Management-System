using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Employee_Management_Systum
{
    public partial class add_dept : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login from.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string loc = Location.Text;
            if (name == "" || loc == "" )
            {
                err1.Visible = true;
                err2.Visible = true;
                

                err1.Text = "Compulsory to fill this fieled ..";
                err2.Text = "Compulsory to fill this fieled ..";
                
            }
            else
            {


                SqlDataAdapter adp = new SqlDataAdapter("insert into dept(dept_name,location) values('" + name + "','" + loc + "')", conn);

               
                adp.Fill(ds);

                Name.Text = "";
                Location.Text = "";

            }

        }
    }
}