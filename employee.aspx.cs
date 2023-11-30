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
    public partial class employee : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from employee", conn);
                adp.Fill(ds);
                
                Emptbl.DataSource= ds;
                Emptbl.DataBind();
            }
            
            if (Session["user"] == null)
            {
                Response.Redirect("login from.aspx");
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from employee where empid='" + EmpUpID.Text + "'", conn);
            adp.Fill(ds);
            int num = ds.Tables[0].Rows.Count;
            if (EmpUpID.Text == "")
            {
                err1.Visible = true;
                err1.Text = "Fill this area compulsory";
            }
            else if (num == 0)
            {
                err1.Visible = true;
                err1.Text = "Enter valid id..!";
            }
            else
            {
                Response.Redirect("empupdate.aspx?id=" + EmpUpID.Text);
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from employee where empid='"+Empid.Text+"'", conn);
            adp.Fill(ds);
            int num = ds.Tables[0].Rows.Count;
            if (Empid.Text == "")
            {
                err1.Visible = true;
                err1.Text = "Fill this area compulsory";
            }
           else if (num == 0)
            {
                err1.Visible = true;
                err1.Text = "Enter valid id..!";
            }
            else
            {
                SqlDataAdapter adp1 = new SqlDataAdapter("Delete from employee where empid='"+Empid.Text+"'",conn);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Emptbl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = (e.CommandArgument).ToString();
            SqlDataAdapter adp = new SqlDataAdapter("Delete from employee where empid='" + id + "'", conn);
            adp.Fill(ds);
            Response.Redirect(Request.RawUrl);
        }

        
    }
}