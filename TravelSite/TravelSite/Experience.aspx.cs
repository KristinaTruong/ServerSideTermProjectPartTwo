using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
namespace TravelSite
{
    public partial class Experience : System.Web.UI.Page
    {

        private DataSet defaultData;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                //copy and paste to check if a user is logged in
                HttpCookie objCookie;
                objCookie = Request.Cookies["TravelSite"];
                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {
                    //defaultData = pxy._____(); //web method here
                    gvAvailable.DataSource = defaultData;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (true) //validation of input
            {

            }
            gvAvailable.DataBind();
        }
    }
}