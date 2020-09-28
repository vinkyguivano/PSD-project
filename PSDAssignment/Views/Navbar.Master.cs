using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PSDAssignment.Repository;

namespace PSDAssignment.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["auth_user"] != null)
            {
                String username = UserRepository.getUserByID(Convert.ToInt32(Session["auth_user"])).Name;
                UserName.Text = "Hi, " + username;
            }


        }
        protected void BtnLogout_Click(object sender, EventArgs e) {
            Session.Clear();
            if (Request.Cookies["auth_user"] != null)
            {
                HttpCookie myCookie = new HttpCookie("auth_user");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            Response.Redirect("Home.aspx");
        }
    }
}