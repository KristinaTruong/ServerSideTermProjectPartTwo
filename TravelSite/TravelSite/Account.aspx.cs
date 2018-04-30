using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using Utilities;

namespace TravelSite
{
    public partial class Account : System.Web.UI.Page
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
                    DataSet ds = CustomerData.getCustomerInfo(objCookie["LoginID"].ToString());

                    //do nothing
                    txtAddress.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtPassword.Text = CustomerData.getCustomerPassword(objCookie.Values["LoginID"].ToString());
                    txtPhone.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtPayment.Text = ds.Tables[0].Rows[0][6].ToString();
                    btnSave.Enabled = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        //need method to update database

        protected void btnEditClick(object sender, EventArgs e)
        {
            successMessage.Visible = false;
            txtAddress.Enabled = true;
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
            txtPhone.Enabled = true;
            txtPayment.Enabled = true;
            btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomerClass updatedCustomer = new CustomerClass();
            updatedCustomer.customerName = txtName.Text;
            updatedCustomer.customerAddress = txtAddress.Text;
            updatedCustomer.customerEmail = txtEmail.Text;
            updatedCustomer.customerPhone = txtPhone.Text;
            updatedCustomer.customerLoginID = txtEmail.Text;
            updatedCustomer.customerPayment = txtPayment.Text;
            updatedCustomer.customerPassword = txtPassword.Text;
            CustomerData.updateCustomer(updatedCustomer);
            txtAddress.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtPassword.Enabled = false;
            txtPhone.Enabled = false;
            txtPayment.Enabled = false;
            btnSave.Enabled = false;
            successMessage.Visible = true;

        }
    }
}