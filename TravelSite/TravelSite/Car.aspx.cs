using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using TravelSite.CarWebService;
using System.Data;

namespace TravelSite
{
    public partial class Car : System.Web.UI.Page
    {
        //proxy objects
        public CarWebService.RentalCarService pxy = new CarWebService.RentalCarService();
        public CarWebService.Car pxyCar = new CarWebService.Car();
        public CarWebService.Customer pxyCustomer = new CarWebService.Customer();
        public CarWebService.Agency pxyAgency = new CarWebService.Agency();

        //search flags

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
                CarWebService.RentalCarService reqs = new RentalCarService();
                CarWebService.Agency agency = new Agency();
                agency.AgencyID = 1;
                DataSet ds= reqs.GetCarsByAgency(agency, "Philadelphia", "PA");
               // reqs.RequirementID = 1;
                //CarWebService.Requirement[] reqArray = { reqs };
                //DataSet ds = pxy.FindCars(reqArray, "", "");
                gvAvailable.DataSource = ds;
                gvAvailable.DataBind();

            }
            //gvAvailable.DataBind();
        }
    }
}