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
        public DataSet ds;

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
                CarWebService.RentalCarService pxy = new RentalCarService();
                CarWebService.Agency agency = new Agency();
                agency.AgencyID = 1;
                ds = pxy.GetCarsByAgency(agency, "Philadelphia", "PA");

                gvAvailable.DataSource = ds;
                gvAvailable.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnAdd.Style["display"] = "inline";
                }
            }
            //gvAvailable.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedCount = 0;
            for (int i = 0; i < gvAvailable.Rows.Count; i++)
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; }
            }
            txtAgency.Text = selectedCount.ToString();
            failedAdd.Style["display"] = "block";
            successfulAdd.Style["display"] = "block";
        }
    }
}