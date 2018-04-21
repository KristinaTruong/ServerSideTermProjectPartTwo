using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TravelSiteLibrary;

namespace TravelSite
{
    public partial class Registration : System.Web.UI.Page
    {
        public Boolean cookieExists = false;
        public HttpCookie cookie = null;
        public CustomerClass loginCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            cookie = Request.Cookies["TravelSite"];
            if (Request.Cookies["TravelSite"] != null)
            {
                cookieExists = true;
                if ((cookie.Values["LoginID"] != null) && (cookie.Values["Password"] != null))
                {
                    Response.Redirect("Homepage.aspx");
                }

            }
            if (!Page.IsPostBack)
            {
                /*
                HttpCookie travelCookie = new HttpCookie("TravelSite");
                travelCookie.Value = "TravelCookie";
                travelCookie.Expires = new DateTime(2019, 1, 1);
                travelCookie.Values["LoginID"] = "tuf54356@temple.edu";
                travelCookie.Values["LastVisited"] = DateTime.Now.ToString();
                Response.Cookies.Add(travelCookie);
                Response.Redirect("Account.aspx");*/
            //---------------------------------
            /*String password = CustomerData.getCustomerPassword("tuf54356@temple.edu");
                testing.Style["display"] = "block";
                testing.InnerText += "PASSWORD:-" + password;*/

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            CustomerClass newCustomer =
                new CustomerClass(txtCustomerEmail.Text,
                txtCustomerName.Text,
                txtCustomerPhone.Text,
                txtCustomerAddress.Text,
                txtCustomerEmail.Text,
                txtCustomerPayment.Text,
                txtCustomerPassword.Text);
            if (CustomerData.checkIfLoginExists(newCustomer))
            {
                invalidLogin.Style["display"] = "block";
                txtCustomerEmail.Text = "";
            }
            else
            {
                CustomerData.createCustomer(newCustomer);
                //validLogin.Style["display"] = "block";


                HttpCookie travelCookie = new HttpCookie("TravelSite");
                travelCookie.Value = "TravelCookie";
                travelCookie.Expires = new DateTime(2025, 1, 1);

                travelCookie.Values["LoginID"] = newCustomer.customerLoginID;
                //travelCookie.Values["Password"] = txtPassword.Text;
                //travelCookie.Values["LastVisited"] = DateTime.Now.ToString();

                //if remember me is checked, set a far off expiration date
                if (chkRemember.Checked == true)
                {
                    travelCookie.Values["Remember"] = "true";
                }
                else
                {
                    travelCookie.Values["Remember"] = "false";
                }
                travelCookie.Values["LoggedIn"] = "true";
                Response.Cookies.Add(travelCookie);

                Response.Redirect("Homepage.aspx");
                //successfulReg.Style["display"] = "block";
            }

        }
    }
}