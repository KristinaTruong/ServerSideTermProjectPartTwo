using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using TravelSite.ExperienceWebService;

namespace TravelSite
{
    public partial class Experience : System.Web.UI.Page
    {

        private DataSet defaultData;
        public DataSet ds;
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
                    //defaultData = pxy._____(); //web method here
                    /*
                    ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
                    DataSet ds = pxy.GetActivityAgencies("PA", "Philadelphia");
                    gvAvailable.AutoGenerateColumns = true;
                    gvAvailable.DataSource = ds;
                    gvAvailable.DataBind();
                    */

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
                ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
                ds = pxy.GetActivityAgencies("PA", "Philadelphia");
                //gvAvailable.AutoGenerateColumns = true;
                gvAvailable.DataSource = ds;
                gvAvailable.DataBind();
            }
            //gvAvailable.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                btnAdd.Style["display"] = "inline";
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedCount = 0;
            for (int i = 0; i < gvAvailable.Rows.Count; i++)
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; }
            }
            //DEBUG
            TextBox2.Text = selectedCount.ToString();
            if (selectedCount == 0)
            {
                failedAdd.Style["display"] = "block";
            }
            else
            {
                VacationPackage vacationPackage = VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString());

                for (int i = 0; i < gvAvailable.Rows.Count; i++)
                {
                    CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                    if (selected.Checked)
                    {
                        ExperienceClass newExp = new ExperienceClass();

                        //AGENCY OBJECT
                        newExp.agency.Agency_id = Convert.ToInt32(gvAvailable.Rows[i].Cells[1].ToString());
                        newExp.agency.Agency_name = gvAvailable.Rows[i].Cells[1].ToString();
                        newExp.agency.Agency_city = gvAvailable.Rows[i].Cells[1].ToString();
                        newExp.agency.Agency_state = gvAvailable.Rows[i].Cells[1].ToString();
                        newExp.agency.Agency_zip = Convert.ToInt32(gvAvailable.Rows[i].Cells[1].ToString());
                        newExp.agency.Agency_phone = gvAvailable.Rows[i].Cells[1].ToString();
                        newExp.agency.Agency_email = gvAvailable.Rows[i].Cells[1].ToString();

                        //ACTIVITY OBJECT
                        //newExp.activity.___

                        //CUSTOMER OBJECT
                        //newExp.customer.___

                        //add experience item to experience array in vacation object
                        vacationPackage.experienceArray.Add(newExp);
                    }

                }
                successfulAdd.Style["display"] = "block";
            }

        }
    }
}