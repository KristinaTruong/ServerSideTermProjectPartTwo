using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;

namespace TravelSite
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie objCookie;
            objCookie = Request.Cookies["TravelSite"];
            Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
            if (loggedIn)
            {
                Response.Redirect("TOS.aspx");
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }

        }
    }
}