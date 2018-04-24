using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSite.ExperienceWebService;
using TravelSiteLibrary;
using System.Data;
namespace TravelSite
{
    public partial class PageTempleASCX : System.Web.UI.UserControl
    {
        public String title { set { pagetitle.InnerText = value; } }
        public String navDefaultHeading { set { navDefault.InnerText = value; } }
        public String navHeading2 { set { navAgency.InnerText = value; } }
        public String navHeading3 { set { navActivity.InnerText = value; } }
        public String navHeading4 { set { navAgencyAndActivity.InnerText = value; } }
        
        public String cityCrit { set { cityCriteria.InnerText = value; } }
        public String stateCrit { set { stateCriteria.InnerText = value; } }
        public String txtbox1head { set { txtbox1Heading.InnerText = value; } }
        public String txtbox2head { set { txtbox2Heading.InnerText = value; } }
        public String txtbox3head { set { txtbox3Heading.InnerText = value; } }
        public String txtbox4head { set { txtbox4Heading.InnerText = value; } }
        public Control failedSearchError { get { return failedSearch; } }
        public Control failedAddError { get { return failedAdd; } }
        public Control noResultserror { get { return noResults; } }
        public Control successfulAddMessage { get { return successfulAdd; } }
        public Control gridview { get { return gvAvailable; } }
        public Control addButton { get { return btnAdd; } }
        public Control searchButton { get { return btnSearch; } }

        //EVENT HANDLERS
        public event EventHandler searchButtonClick;
        public event EventHandler addButtonClick;


        public object noResultsError { get; internal set; }

        public DataSet defaultData;
        public DataSet ds; //set up dataset
        public HttpCookie objCookie; //setup cookie
        public VacationPackage myPackage; //user's vacation package
        public ExperienceClass newExp;
        public String method = ""; //string to carry web method name
        //this will be used to know which column to extract the correct value for creating an object
        //because methods may return different fields 

        public void Page_Load(object sender, EventArgs e)
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
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.searchButtonClick != null)
                this.searchButtonClick(this, e);
        }
        


        /*
        public  void btnSearch_Click(object sender, EventArgs e)
        {
            reset();
            gvAvailable.DataSource = null;
            ds = null;
            ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
            if (validateRequirements())
            {
                if (ViewState["method"] != null)
                {
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

                                    btnAdd.Enabled = true;
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }
                            break;
                        case "byAgency":
                            if (validate2())
                            {
                                ExperienceWebService.Agency agency = new Agency();
                                agency.Agency_id = Convert.ToInt32(txtbox1.Text);

                                ds = pxy.GetActivities(agency, txtState.Text, txtCity.Text); //get appropriate dataset
                                if (ds != null)
                                {
                                    gvAvailable.DataSource = ds; //assign as datasource

                                    gvAvailable.DataBind(); //databind it to gridview
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        btnAdd.Enabled = true;

                                    }
                                    else
                                    { noResults.Style["display"] = "block"; }
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }

                            break;
                        case "byActivity":
                            if (txtbox2.Text != "")
                            {

                                ExperienceWebService.Activities activity = new Activities();
                                activity.Activity_type = txtbox2.Text;
                                activity.Activity_startDate = "02/02/2018";
                                activity.Activity_enddate = "02/03/2018";
                                ds = null;
                                ds = pxy.FindActivities(activity, txtState.Text, txtCity.Text); //get appropriate dataset
                                if (ds != null)
                                {
                                    gvAvailable.DataSource = ds; //assign as datasource

                                    gvAvailable.DataBind(); //databind it to gridview
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {

                                        btnAdd.Enabled = true;
                                    }
                                    else
                                    { noResults.Style["display"] = "block"; }

                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; valtxtbox2.Style["display"] = "inline"; }
                            break;
                        case "byVenue":

                            break;
                        case "byAgencyAndActivity":

                            break;
                        default:
                            ds = pxy.GetActivityAgencies(txtState.Text, txtCity.Text); //get appropriate dataset
                            if (ds != null)
                            {
                                gvAvailable.DataSource = ds; //assign as datasource
                                gvAvailable.DataBind(); //databind it to gridview
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                    btnAdd.Enabled = true;
                                }
                                else
                                { noResults.Style["display"] = "block"; }
                            }
                            else
                            { noResults.Style["display"] = "block"; }
                            break;
                    }
                }
            }
            else
            {
                ViewState["method"] = "default";
            }
        }
        */
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.addButtonClick != null)
                this.addButtonClick(this, e);
        }
        /*
        public void btnAdd_Click(object sender, EventArgs e)
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
        */
        //---------------------------------------------------------------------------------------------------------------------
        //PRIVATE METHODS -----------------------------------------------------------------------------------------------------

        public Boolean validateRequirements()
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

        public Boolean validate2()
        {
            Boolean valid = true;
            if (txtbox1.Text == "")
            {
                failedSearch.Style["display"] = "block";
                txtbox1.Style["display"] = "inline";
                valid = false;
            }
            else if (txtbox1.Text != "")
            {
                try
                {
                    int convertedID = Convert.ToInt32(txtbox1.Text);
                }
                catch (FormatException e)
                {
                    valid = false;
                }
            }
            return valid;
        }
        public void reset() //resets error and validation messages
        {
            //reset error messagess
            failedAdd.Style["display"] = "none";
            successfulAdd.Style["display"] = "none";
            failedSearch.Style["display"] = "none";
            noResults.Style["display"] = "none";
            //reset validation
            valCity.Style["display"] = "none";
            valState.Style["display"] = "none";
            valtxtbox1.Style["display"] = "none";
            valtxtbox2.Style["display"] = "none";
            valtxtbox3.Style["display"] = "none";
            valtxtbox4.Style["display"] = "none";
        }

        public void resetSearch() //resets search section visibility
        {
            searchDefault.Style["display"] = "none";
            search2.Style["display"] = "none";
            search3.Style["display"] = "none";
            search4.Style["display"] = "none";

        }

        //-------------------------------------------------------------------------------------------------------------
        //SPECIFIES WEB METHOD IN VIEW STATE OBJECT DEPENDING ON SEARCH TAB THAT WAS CLICKED
        public void displayDefault(object Source, EventArgs e) //search for agencies
        {
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            ViewState["method"] = "default";
            searchDefault.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display2(object Source, EventArgs e) //search by agencies
        {

            ViewState["method"] = "byAgency";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search2.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display3(object Source, EventArgs e) //search by activity
        {
            ViewState["method"] = "byActivity";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search3.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

        public void display4(object Source, EventArgs e) //search by agency and activity
        {
            ViewState["method"] = "byAgencyAndActivity";
            resetSearch();
            buttonSection.Style["visibility"] = "visible";
            searchDefault.Style["display"] = "block";
            search4.Style["display"] = "block";
            introSection.Style["display"] = "none";
        }

    }

}