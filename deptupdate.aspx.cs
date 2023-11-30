using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_Systum
{
    public partial class deptupdate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                string dept_id = Request.QueryString["id"];
                SqlCommand cmd = new SqlCommand("select * from dept where dept_id = '" + dept_id + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                {

                    while (reader.Read())
                    {
                        Name.Text = reader["dept_name"].ToString();
                        Loc.Text = reader["location"].ToString();
                    }
                }
                if (Session["user"] == null)
                {
                    Response.Redirect("login from.aspx");
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["id"];
            
            
               
                SqlDataAdapter adp = new SqlDataAdapter("update  dept set dept_name='" + Name.Text + "', location='" + Loc.Text + "' where dept_id='" + dept_id + "'", conn);
                adp.Fill(ds);
                Response.Redirect("department.aspx");
            
        }
    }
}