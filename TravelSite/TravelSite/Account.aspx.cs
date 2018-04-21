using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;

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
                    txtEmail.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtPassword.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0][5].ToString();
                    btnSave.Enabled = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void btnEditClick(object sender, EventArgs e)
        {
            txtAddress.Enabled = true;
            txtName.Enabled = true;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
            txtPhone.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}