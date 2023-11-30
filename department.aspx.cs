using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_Systum
{
    public partial class department : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from dept", conn);
                adp.Fill(ds);
                Emptbl.DataSource = ds;
                Emptbl.DataBind();
            }
            if (Session["user"] == null)
            {
                Response.Redirect("login from.aspx");
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from dept where dept_id='" + Deptid.Text + "'", conn);
            adp.Fill(ds);
            int num = ds.Tables[0].Rows.Count;
            if (Deptid.Text == "")
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
                SqlDataAdapter adp1 = new SqlDataAdapter("Delete from dept where dept_id='" + Deptid.Text + "'", conn);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from dept where dept_id='" + Deptid1.Text + "'", conn);
            adp.Fill(ds);
            int num = ds.Tables[0].Rows.Count;
            if (Deptid1.Text == "")
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
                Response.Redirect("deptupdate.aspx?id=" + Deptid1.Text);

            }
        }

        protected void Emptbl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = (e.CommandArgument).ToString();
            SqlDataAdapter adp = new SqlDataAdapter("Delete from dept where dept_id='" + id + "'", conn);
            adp.Fill(ds);
            Response.Redirect(Request.RawUrl);
        }
    }
}