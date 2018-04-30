using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using TravelSite.ExperienceWebService2;
using TravelSite.HotelWebService;
using TravelSite.CarWebService;

namespace TravelSite
{
    public partial class MyVacationPackage : System.Web.UI.Page
    {
        HttpCookie objCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //copy and paste to check if a user is logged in
               
                objCookie = Request.Cookies["TravelSite"];
                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {
                    //DEBUG-------------------------------------
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
                    gvHotel.DataBind();
                    */
                    //---------------------------------------
                    VacationPackage package =  VacationPackage.getCustomerPackage(objCookie["LoginID"]);
                    gvHotel.DataSource = package.hotelArray;
                    gvCar.DataSource = package.carArray;
                    gvFlight.DataSource = package.flightArray;
                    gvActivity.DataSource = package.experienceArray;
                    gvHotel.DataBind();gvCar.DataBind();gvFlight.DataBind();gvActivity.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            Boolean completed = true;
            VacationPackage package = VacationPackage.getCustomerPackage(objCookie["LoginID"]);
            List<ExperienceClass> expList = package.experienceArray;
            for (int i = 0; i< expList.Count; i++)
            {
                ExperienceClass item = expList[i];
                ExperienceWebService2.Agencies agency = new Agencies();
                agency.agenciesID = item.Agency_id.ToString();

                ExperienceWebService2.Activity activity = new Activity();
                activity.activityID = item.Activity_id.ToString();

                ExperienceWebService2.Customer customer = new ExperienceWebService2.Customer();
                DataSet ds = CustomerData.getCustomerInfo(objCookie["LoginID"]);
               
                customer.customerFirstName = ds.Tables[0].Rows[0][1].ToString();
                customer.customerLastName = ds.Tables[0].Rows[0][1].ToString();
                customer.customerAddress = ds.Tables[0].Rows[0][2].ToString();

                ExperienceWebService2.ActivitiesService pxy = new ActivitiesService();
                Boolean reserved = pxy.Reserve(agency, activity, customer, "Activity", "Activity");
                if (reserved == false) { item.reserved = false; completed = false; }
                if(reserved == true) { item.reserved = true; }
            }

            List<CarClass> carList = package.carArray;
            for (int i = 0; i < expList.Count; i++)
            {
                DataSet ds = CustomerData.getCustomerInfo(objCookie["LoginID"]);

                CarClass item = new CarClass();
                CarWebService.Car car = new CarWebService.Car();
                car.carID = Convert.ToInt32(item.CarID);
                car.carcost = Convert.ToDecimal(item.Cost);

                CarWebService.Customer customer = new CarWebService.Customer();
                customer.Name = ds.Tables[0].Rows[0][1].ToString();
                customer.Email = ds.Tables[0].Rows[0][1].ToString();
                CarWebService.CarService pxy = new CarWebService.CarService();
                Boolean reserved = pxy.Reserve(item.agencyID, car, customer, 1, "Vacation2018");
                if (reserved == false) { item.reserved = false; completed = false; }
                if (reserved == true) { item.reserved = true; }
            }

            List<FlightClass> flightList = package.flightArray;
            for (int i = 0; i < expList.Count; i++)
            {
                DataSet ds = CustomerData.getCustomerInfo(objCookie["LoginID"]);

                FlightClass item = new FlightClass();
                CarWebService.Car car = new CarWebService.Car(); // CHANGE 
                car.carID = Convert.ToInt32(item.CarID);
                car.carcost = Convert.ToDecimal(item.Cost);

                CarWebService.Customer customer = new CarWebService.Customer();
                customer.Name = ds.Tables[0].Rows[0][1].ToString();
                customer.Email = ds.Tables[0].Rows[0][1].ToString();
                CarWebService.CarService pxy = new CarWebService.CarService();
                Boolean reserved = pxy.Reserve(item.agencyID, car, customer, 1, "Vacation2018");
                if (reserved == false) { item.reserved = false; completed = false; }
                if (reserved == true) { item.reserved = true; }
            }

            List<HotelClass> hotelList = package.hotelArray;
            for (int i = 0; i < expList.Count; i++)
            {
                DataSet ds = CustomerData.getCustomerInfo(objCookie["LoginID"]);

                FlightClass item = new FlightClass();
                CarWebService.Car car = new CarWebService.Car(); // CHANGE 
                car.carID = Convert.ToInt32(item.CarID);
                car.carcost = Convert.ToDecimal(item.Cost);

                CarWebService.Customer customer = new CarWebService.Customer();
                customer.Name = ds.Tables[0].Rows[0][1].ToString();
                customer.Email = ds.Tables[0].Rows[0][1].ToString();
                CarWebService.CarService pxy = new CarWebService.CarService();
                Boolean reserved = pxy.Reserve(item.agencyID, car, customer, 1, "Vacation2018");
                if (reserved == false) { item.reserved = false; completed = false; }
                if (reserved == true) { item.reserved = true; }
            }

            if (completed == false)
            {

            }
            else
            {
                VacationPackage.archivePackage();
            }
        }
    }
}