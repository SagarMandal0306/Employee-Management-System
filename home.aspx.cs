using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_Systum
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = (string)Session["user"];
            if(user!= null)
            {
                User.Text = user;
            }
            else
            {
                User.Text = "Guest";
            }
        }

       

        protected void Logout1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }
    }
}