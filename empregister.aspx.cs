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
    public partial class empregister : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ems;Integrated Security=True;Pooling=False");
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login from.aspx");
            }
            if (!IsPostBack)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from dept",conn);
                adp.Fill(ds);
                Dept.DataTextField = "dept_name";
                Dept.DataValueField = "dept_id";
                Dept.DataSource = ds;
                Dept.DataBind();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string desg = Desg.Text;
            string dept = Dept.SelectedItem.Text;
            string salary = Salary.Text;
            string img = "~/img/"+FileUpload1.FileName;



            if (name == "" || desg == "" || dept == "" || salary == "" || img == "")
            {
                err1.Visible = true;
                err2.Visible = true;
                err3.Visible = true;
                err4.Visible = true;
                err5.Visible = true;

                err1.Text = "Compulsory to fill this fieled ..";
                err2.Text = "Compulsory to fill this fieled ..";
                err3.Text = "Compulsory to fill this fieled ..";
                err4.Text = "Compulsory to fill this fieled ..";
                err5.Text = "Compulsory to fill this fieled ..";
            }
            else
            {


                SqlDataAdapter adp = new SqlDataAdapter("insert into employee(ename,desg,dept,salary,image) values('" + name + "','" + desg + "','" + dept + "','" + salary + "','" + img + "')", conn);

                FileUpload1.SaveAs(Server.MapPath(img));
                adp.Fill(ds);

                Response.Redirect(Request.RawUrl);

            }


        }


    }
}