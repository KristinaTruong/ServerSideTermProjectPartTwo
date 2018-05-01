using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using TravelSiteLibrary;
using TravelSite.ExperienceWebService2;
using TravelSite.HotelWebService;
using TravelSite.CarWebService;


namespace TravelSite
{
    public partial class MyVacationPackage : System.Web.UI.Page
    {
        HttpCookie objCookie;
        Boolean hotelBool;
        Boolean carBool;
        Boolean flightBool;
        Boolean experienceBool;
        VacationPackage package;
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
                  
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (VacationPackage.getCustomerPackage(objCookie["LoginID"].ToString()) != null) { package = VacationPackage.getCustomerPackage(objCookie["LoginID"].ToString()); }
                else { package = new VacationPackage(); }

                if (package.hotelArray != null && package.hotelArray.Count != 0) { gvHotel.DataSource = package.hotelArray; gvHotel.DataBind(); hotelBool = true; }
                else { hotelBool = false; }
                if (package.carArray != null && package.carArray.Count != 0) { gvCar.DataSource = package.carArray; gvCar.DataBind(); carBool = true; }
                else { carBool = false; }
                if (package.flightArray != null && package.flightArray.Count != 0) { gvFlight.DataSource = package.flightArray; gvFlight.DataBind(); flightBool = true; }
                else { flightBool = false; }
                if (package.experienceArray != null && package.experienceArray.Count != 0) { gvActivity.DataSource = package.experienceArray; gvActivity.DataBind(); experienceBool = true; }
                else { experienceBool = false; }

                //Bind all the data to the gridviews
                gvActivity.DataBind();
                gvFlight.DataBind();
                gvCar.DataBind();
                gvHotel.DataBind();
            }
            
        }

        /*
         * Go through all Vacation object lists, and purchase / reserve each object along the way
         * */
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
                //if successfully purchased, set the reserved flag to true
                //if not, set to false
                //this flag will allow the page to know whether or not to notify if the customer needs ot edit or delete an item in their package
                //that is no longer available since the last time they added the item to their vacation package cart

            }

            List<CarClass> carList = package.carArray;
            for (int i = 0; i < carList.Count; i++)
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
            for (int i = 0; i < flightList.Count; i++)
            {
                /*
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
                if (reserved == true) { item.reserved = true; }*/
            }

            List<HotelClass> hotelList = package.hotelArray;
            for (int i = 0; i < hotelList.Count; i++)
            {
                /*
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
                if (reserved == true) { item.reserved = true; }*/
            }

            if (completed == false)
            {

            }
            else
            {
                //VacationPackage.archivePackage();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Boolean completed = true;
            package = VacationPackage.getCustomerPackage(objCookie["LoginID"]);

            if (experienceBool)
            {
                List<ExperienceClass> expList = package.experienceArray;
                for (int i = 0; i < expList.Count; i++)
                {
                    if (gvActivity.Rows.Count > 0)
                    {
                        if (((CheckBox)gvActivity.Rows[i].FindControl("chkSelect")).Checked)
                        {
                            package.experienceArray.RemoveAt(i);
                        }
                    }

                }
            }
            if (carBool)
            {
                List<CarClass> carList = package.carArray;
                for (int i = 0; i < carList.Count; i++)
                {
                    if (gvCar.Rows.Count > 0)
                    {
                        if (((CheckBox)gvCar.Rows[i].FindControl("chkSelect")).Checked)
                        {
                            package.carArray.RemoveAt(i);
                        }
                    }
                }
            }
            if (flightBool)
            {
                List<FlightClass> flightList = package.flightArray;
                for (int i = 0; i < flightList.Count; i++)
                {
                    if (gvFlight.Rows.Count > 0)
                    {
                        if (((CheckBox)gvFlight.Rows[i].FindControl("chkSelect")).Checked)
                        {
                            package.flightArray.RemoveAt(i);
                        }
                    }
                }
            }
            if (hotelBool)
            {
                 List<HotelClass> hotelList = package.hotelArray;
                for (int i = 0; i < hotelList.Count; i++)
                {
                    if (gvHotel.Rows.Count > 0)
                    {
                        if (((CheckBox)gvHotel.Rows[i].FindControl("chkSelect")).Checked)
                        {
                            package.hotelArray.RemoveAt(i);
                        }
                    }
                }
            }
            VacationPackage.updatePackage(objCookie.Values["LoginID"].ToString(), VacationPackage.getCustomerPackage(objCookie["LoginID"]));
            if (completed == false)
            {

            }
            else
            {
                //VacationPackage.archivePackage();
            }
        }
    }
}