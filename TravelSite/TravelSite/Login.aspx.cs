using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelSite
{
    public partial class Login : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["TravelSite"] != null)
            {
                HttpCookie cookie = Request.Cookies["TravelSite"];
                txtUserNm.Text = cookie.Values["UserName"].ToString();
                txtPassword.Text = cookie.Values["Password"].ToString();
            }

        }

        protected void lbtnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {




        }
    }
}
