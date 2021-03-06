﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;

namespace TravelSite
{
    public partial class Login : System.Web.UI.Page

    {
        public Boolean cookieExists = false;
        public HttpCookie cookie = null;
        public CustomerClass loginCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            cookie = Request.Cookies["TravelSite"];
            if (Request.Cookies["TravelSite"] != null) //cookie exists
            { 
                if(cookie.Values["LoggedIn"].ToString() == "true"){
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    txtUserNm.Text = cookie.Values["LoginID"].ToString();
                }

            }
            else
            {
                //do nothing
            }

            /*
            if (!IsPostBack)
            {
                if (Request.Cookies["TravelSite"] != null)
                {
                    cookieExists = true;
                    cookie = Request.Cookies["TravelSite"];
                    if (cookie.Values["LoginID"] != null) { txtUserNm.Text = cookie.Values["LoginID"].ToString(); }

                    if (cookie.Values["Password"] != null) { txtPassword.Text = cookie.Values["Password"].ToString(); }
                }
                else { }
            }*/

        }

        protected void lbtnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginCustomer = new CustomerClass();
            loginCustomer.customerLoginID = txtUserNm.Text;
            String enteredPassword = txtPassword.Text;

            if (CustomerData.checkIfLoginExists(loginCustomer))
            {
                String correctPassword = CustomerData.getCustomerPassword(txtUserNm.Text);
                if (enteredPassword == correctPassword)
                {
                    if (!cookieExists)
                    {
                        CustomerClass newCustomer = new CustomerClass();
                        newCustomer.customerLoginID = txtUserNm.Text.ToString();
                        newCustomer.customerPassword = txtPassword.Text.ToString();
                        HttpCookie travelCookie = new HttpCookie("TravelSite");
                        travelCookie.Value = "TravelCookie";
                        travelCookie.Expires = new DateTime(2025, 1, 1);

                        travelCookie.Values["LoginID"] = newCustomer.customerLoginID;
                        //travelCookie.Values["Password"] = txtPassword.Text;
                        //travelCookie.Values["LastVisited"] = DateTime.Now.ToString();

                        //if remember me is checked, set a far off expiration date
                        if(rememberMe.Checked == true)
                        {
                            travelCookie.Values["Remember"] = "true";
                        }
                        else
                        {
                            travelCookie.Values["Remember"] = "false";
                        }
                        travelCookie.Values["LoggedIn"] = "true";
                        Response.Cookies.Add(travelCookie);
                    }
                    else
                    {
                        cookie.Expires = new DateTime(2025, 1, 1);
                        cookie.Values["LoginID"] = txtUserNm.Text;
                        cookie.Values["LoggedIn"] = "true";
                        //cookie.Values["Password"] = txtPassword.Text;
                        //if remember me is checked, set a far off expiration date
                        if (rememberMe.Checked == true)
                        {
                            cookie.Values["Remember"] = "true";
                        }
                        else
                        {
                            cookie.Values["Remember"] = "false";
                        }
                        Response.Cookies.Add(cookie);
                    }
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    wrongPassword.Style["display"] = "block";
                }
            }
            else
            {
                wrongPassword.Style["display"] = "block";
            }



        }
    }
}
