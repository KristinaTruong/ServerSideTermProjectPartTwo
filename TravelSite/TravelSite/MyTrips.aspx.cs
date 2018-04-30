using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
namespace TravelSite
{
    public partial class MyTrips : System.Web.UI.Page
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
                    //DEBUG------------------------------------------
                    /*
                    List<CarClass> carArray = new List<CarClass>();
                    CarClass car1 = new CarClass(1);
                    carArray.Add(car1);
                    CarClass car2 = new CarClass(1);
                    carArray.Add(car2);
                    CarClass car3 = new CarClass(1);
                    carArray.Add(car3);
                    CarClass car4 = new CarClass(1);
                    carArray.Add(car4);
                    gvHotel.DataSource = carArray;
                    gvHotel.DataBind();*/
                    //--------------------------------------------------
                    //VacationPackage currentPackage = VacationPackage.getCustomerPackage(objCookie["LoginID"].ToString());
                    gvTrips.DataSource = VacationPackage.getPastTrips(objCookie["LoginID"]);
                    gvTrips.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        protected void btnSeeMore_Click(object sender, EventArgs e)
        {
            VacationPackage.getTripInfo(Convert.ToInt32(gvHotel.SelectedRow.Cells[0].Text));

        }
    }
}