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
        String method = ""; //string to carry web method name
        //this will be used to know which column to extract the correct value for creating an object
        //because methods may return different fields 

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
            reset();
            ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
            if (validateRequirements())
            {
                if (ViewState["method"] != null) {
                switch (ViewState["method"].ToString())
                {
                    case "default":
                        ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                        if (ds != null)
                        {
                            gvAvailable.DataSource = ds; //assign as datasource

                            gvAvailable.DataBind(); //databind it to gridview
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtCity.Text = "GOT HERE";
                                btnAdd.Enabled = true;
                            }
                        }
                        break;
                    case "byAgency":
                        ExperienceWebService.Agency agency = new Agency();
                        agency.Agency_id = Convert.ToInt32(txtAgencyID.Text);
                        ds = pxy.GetActivities(agency,txtState.Text, txtCity.Text); //get appropriate dataset
                        if (ds != null)
                        {
                            gvAvailable.DataSource = ds; //assign as datasource

                            gvAvailable.DataBind(); //databind it to gridview
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtCity.Text = "GOT HERE";
                                btnAdd.Enabled = true;
                            }
                        }
                        break;
                    case "byActivity":
                        ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                        if (ds != null)
                        {
                            gvAvailable.DataSource = ds; //assign as datasource

                            gvAvailable.DataBind(); //databind it to gridview
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtCity.Text = "GOT HERE";
                                btnAdd.Enabled = true;
                            }
                        }
                        break;
                    case "byVenue":
                        ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                        if (ds != null)
                        {
                            gvAvailable.DataSource = ds; //assign as datasource

                            gvAvailable.DataBind(); //databind it to gridview
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtCity.Text = "GOT HERE";
                                btnAdd.Enabled = true;
                            }
                        }
                        break;
                    case "byAgencyAndActivity":
                        ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                        if (ds != null)
                        {
                            gvAvailable.DataSource = ds; //assign as datasource

                            gvAvailable.DataBind(); //databind it to gridview
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtCity.Text = "GOT HERE";
                                btnAdd.Enabled = true;
                            }
                        }
                        break;
                    default:
                        ViewState["method"] = "default";
                        break;
                }
                }
            }
            else
            {
                ViewState["method"] = "default";
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            reset();
            int selectedCount = 0; //count number selected
            for (int i = 0; i < gvAvailable.Rows.Count; i++) //count
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; } //if selected, increment counter
            }
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

        //PRIVATE METHODS -----------------------------------------------------------------------------------------------------
        private Boolean validateRequirements()
        {
            Boolean valid = true;
            if (txtCity.Text == "")
            {
                valid = false;
                valCity.Style["display"] = "inline";
                failedSearch.Style["display"] = "block";
            }
            if (txtState.Text == "")
            {
                valid = false;
                valState.Style["display"] = "inline";
                failedSearch.Style["display"] = "block";
            }
            return valid;
        }

        private Boolean validateAgency()
        {
            Boolean valid = true;
            if (txtAgencyID.Text == "")
            {

            }
            return valid;
        }
        private void reset()
        {
            //reset error messagess
            failedAdd.Style["display"] = "none";
            successfulAdd.Style["display"] = "none";
            failedSearch.Style["display"] = "none";
            //reset validation
            valCity.Style["display"] = "none";
            valState.Style["display"] = "none";
        }

        private void resetSearch()
        {
            searchDefault.Style["display"] = "none";
            searchAgency.Style["display"] = "none";
            searchActivity.Style["display"] = "none";
            searchAgencyAndActivity.Style["display"] = "none";
            searchVenue.Style["display"] = "none";
        }

        protected void displayDefault(object Source, EventArgs e)
        {
            resetSearch();
            ViewState["method"] = "default";
            searchDefault.Style["display"] = "block";
        }

        protected void displayAgency(object Source, EventArgs e)
        {
            ViewState["method"] = "byAgency";
            resetSearch();
            searchDefault.Style["display"] = "block";
            searchAgency.Style["display"] = "block";
        }

        protected void displayActivity(object Source, EventArgs e)
        {
            ViewState["method"] = "byActivity";
            resetSearch();
            searchDefault.Style["display"] = "block";
            searchActivity.Style["display"] = "block";
        }

        protected void displayAgencyAndActivity(object Source, EventArgs e)
        {
            ViewState["method"] = "byAgencyAndActivity";
            resetSearch();
            searchDefault.Style["display"] = "block";
            searchAgencyAndActivity.Style["display"] = "block";
        }

        protected void displayVenue(object Source, EventArgs e)
        {
            ViewState["method"] = "byVenue";
            resetSearch();
            searchDefault.Style["display"] = "block";
            searchVenue.Style["display"] = "block";
        }


    }
}