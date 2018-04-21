using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;

namespace TravelSite
{
    public partial class Logout : System.Web.UI.Page
    {
        public Boolean cookieExists = false;
        public HttpCookie cookie = null;
        public CustomerClass loginCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            cookie = Request.Cookies["TravelSite"];
            if (Request.Cookies["TravelSite"] != null) //cookie exists
            {
                //see if to keep cookie if remember me was selected
                if (cookie.Values["Remember"].ToString() == "true")
                {
                    cookie.Values["LoggedIn"] = "false";
                    //if selected, assigned loggedin as false,
                    //so that user must sign in again
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    //else, if do not remember
                    //delete the cookie entirely
                    cookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(cookie);
                }

            }
            else
            {

            }
            //finally, redirect to the Login page
            //Response.Redirect("Login.aspx");
        }
    }
}