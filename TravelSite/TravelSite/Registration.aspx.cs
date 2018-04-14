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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                String password = CustomerData.getCustomerPassword("tuf54356@temple.edu");
                testing.Style["display"] = "block";
                testing.InnerText += "PASSWORD:-" + password;

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
            }

        }
    }
}