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
        public DataSet ds; //set up dataset
        HttpCookie objCookie; //setup cookie
        VacationPackage myPackage; //user's vacation package
        ExperienceClass newExp;

        protected void Page_Load(object sender, EventArgs e)
        {
            objCookie = Request.Cookies["TravelSite"];

            if (!Page.IsPostBack)
            {
                //copy and paste to check if a user is logged in

                Boolean loggedIn = CustomerData.checkForLoginCookie(objCookie);
                if (loggedIn)
                {
                    myPackage = VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString());
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            failedAdd.Style["display"] = "none";
            failedAdd.Style["display"] = "none";


            if (true) //validation of input --------------------------------------------------------FILL
            {
                if (true)//----------------------------------FILL WITH PARAMETERS if-else then statements
                {
                    ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
                    ds = pxy.GetActivityAgencies("PA", "Philadelphia"); //get appropriate dataset
                    gvAvailable.DataSource = ds; //assign as datasource
                    gvAvailable.DataBind(); //databind it to gridview
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnAdd.Enabled = true;
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int selectedCount = 0; //count number selected
            for (int i = 0; i < gvAvailable.Rows.Count; i++) //count
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; } //if selected, increment counter
            }

            //DEBUG
            //txtAgency.Text = selectedCount.ToString();

            if (selectedCount == 0) //if none selected
            {
                failedAdd.Style["display"] = "block";
            }

            else //if at least one selected
            {
                //reloop through gridview
                for (int j = 0; j < gvAvailable.Rows.Count; j++)
                {
                    //if the select box is checked..
                    CheckBox selected = (CheckBox)gvAvailable.Rows[j].FindControl("chkSelect");
                    if (selected.Checked == true)
                    {
                        //create a new object
                        ExperienceClass newExp = new ExperienceClass();
                        //initialize its properities to the record's values that was chosen
                        newExp.Agency_id = 1;

                        //if a vacation package exists
                        if (VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString()) == null)
                        {
                            myPackage = new VacationPackage(); //if not, create a new one
                        }
                        else
                        {
                            //if yes, retrieve the package
                            myPackage = VacationPackage.getCustomerPackage(objCookie.Values["LoginID"].ToString());
                        }
                        //finally, add the new object to the vacation package's appropriate list
                        myPackage.experienceArray.Add(newExp);
                    }
                }
                //update the vacation package in the database
                VacationPackage.updatePackage(objCookie.Values["LoginID"].ToString(), myPackage);
                successfulAdd.Style["display"] = "block";
            }

        }
    }
}