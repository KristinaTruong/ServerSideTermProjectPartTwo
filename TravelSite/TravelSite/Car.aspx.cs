using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;

namespace TravelSite
{
    public partial class Car : System.Web.UI.Page
    {
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
                    //do nothing
                    //Control myCtrl = LoadControl("PageTemplateASCX.ascx"); Form.Controls.Add(myCtrl);
                    /*
                    PageTempleASCX myCtrl = (PageTempleASCX)LoadControl("PageTemplateASCX.ascx");
                    Form.Controls.Add(myCtrl);*/
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
            //gvAvailable.DataBind();
        }
    }
}