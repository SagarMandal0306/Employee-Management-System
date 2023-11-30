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
    public partial class empupdate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                string empid = Request.QueryString["id"];
                SqlCommand cmd = new SqlCommand("select * from employee where empid = '" + empid + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    

                    while (reader.Read())
                    {
                        Name.Text = reader["ename"].ToString();
                        Desg.Text = reader["desg"].ToString();
                        
                        Dept.SelectedItem.Text = reader["dept"].ToString();
                        Salary.Text = reader["salary"].ToString();
                        Image1.ImageUrl = reader["image"].ToString();
                    }
                    conn.Close();
                }
                if (Session["user"] == null)
                {
                    Response.Redirect("login from.aspx");
                }

            }
            //if (!IsPostBack)
            //{
            //    SqlDataAdapter adp1 = new SqlDataAdapter("select dept_name from dept ", conn);
            //    DataSet ds1 = new DataSet();
            //    adp1.Fill(ds1);
            //    Dept.DataTextField = "dept_name";
            //    //Dept.DataValueField = "dept_id";
            //    Dept.DataSource = ds1;
            //    Dept.DataBind();
            //}
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string empid = Request.QueryString["id"];
            if (FileUpload1.FileName=="")
            {
                SqlDataAdapter adp = new SqlDataAdapter("update  employee set ename='" + Name.Text + "', desg='" + Desg.Text + "',dept='" + Dept.SelectedItem.Text + "',salary='"+Salary.Text+ "' where empid='"+empid+"'", conn);
                adp.Fill(ds);
                Response.Redirect("employee.aspx");
            }
            else
            {
                string img = "~/img/" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(img));
                SqlDataAdapter adp = new SqlDataAdapter("update  employee set ename='" + Name.Text + "', desg='" + Desg.Text + "',dept='" + Dept.SelectedItem.Text + "',salary='" + Salary.Text + "',image='"+img+"' where empid='"+empid+"'", conn);
                adp.Fill(ds);
                Response.Redirect("employee.aspx");
            }
        }
    }
}