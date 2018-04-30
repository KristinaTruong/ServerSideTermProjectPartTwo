using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using System.Data;
using TravelSite.ExperienceWebService2;

namespace TravelSite
{
    public partial class TestPage : System.Web.UI.Page
    {
        Button myaddButton;
        Button mysearchButton;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                

                this.PageTemplateASCX.title = "Test Page";
                this.PageTemplateASCX.navDefaultHeading = "Get Activity Agencies";

                //search sections
                this.PageTemplateASCX.navHeading2 = "Get Activities";
                this.PageTemplateASCX.navHeading3 = "Find Activities";
                this.PageTemplateASCX.navHeading4 = "Find Activities By Venue";
                this.PageTemplateASCX.navHeading5 = "Find Activities By Agency";

                //defaultSearch
                this.PageTemplateASCX.cityCrit = "City";
                this.PageTemplateASCX.stateCrit = "State";
                this.PageTemplateASCX.txtbox3head = "Agency ID";
                this.PageTemplateASCX.txtbox9head = "Activity Type";
                this.PageTemplateASCX.txtbox10head = "Venue Name";
                this.PageTemplateASCX.txtbox12head = "Activity Type";
                this.PageTemplateASCX.txtbox13head = "Agency Name";
                this.PageTemplateASCX.hideTxtBox1();
                this.PageTemplateASCX.hideTxtBox2();
                this.PageTemplateASCX.hideTxtBox8();

                this.PageTemplateASCX.txtbox6head = "Activity Type";
                this.PageTemplateASCX.txtbox7head = "Activity Day";

                this.PageTemplateASCX.hideTxtBox4();
                this.PageTemplateASCX.hideTxtBox5();
                this.PageTemplateASCX.hideTxtBox11();
                this.PageTemplateASCX.hideTxtBox14();
                /*
                this.PageTemplateASCX.txtbox1head = "Agency ID";
                this.PageTemplateASCX.txtbox2head = "Agency ID";
                //search2
                this.PageTemplateASCX.txtbox3head = "Agency ID";
                this.PageTemplateASCX.txtbox4head = "Agency ID";
                this.PageTemplateASCX.txtbox5head = "Agency ID";
                //search3
                this.PageTemplateASCX.txtbox6head = "Agency ID";
                this.PageTemplateASCX.txtbox7head = "Agency ID";
                this.PageTemplateASCX.txtbox8head = "Agency ID";
                //search4
                this.PageTemplateASCX.txtbox9head = "Agency ID";
                this.PageTemplateASCX.txtbox10head = "Agency ID";
                this.PageTemplateASCX.txtbox11head = "Agency ID";
                */
                //buttons
               


            }
            myaddButton = (Button)this.PageTemplateASCX.addButton;
            mysearchButton = (Button)this.PageTemplateASCX.searchButton;
            this.PageTemplateASCX.searchButtonClick += new EventHandler(search);
            this.PageTemplateASCX.addButtonClick += new EventHandler(add);
            //ViewState["dataSource"] = this.PageTemplateASCX.ds;

        }
        
        //search button event - added to the control
        private void search(object sender, System.EventArgs e)
        {
            ((GridView)this.PageTemplateASCX.gridview).DataBind();
            this.PageTemplateASCX.reset();
            //((GridView)this.PageTemplateASCX.gridview).DataSource = null;
           // this.PageTemplateASCX.ds = null;

            //CHANGE THIS-----------------------------------------------------------------------------------------FILL
            ExperienceWebService2.ActivitiesService pxy = new ExperienceWebService2.ActivitiesService();

            //check if mandatory fields were filled out
            //in this case, city and state must be filled out for every search
            Boolean valid = true;
            if (((TextBox)this.PageTemplateASCX.cityCritbox).Text == "")
            {
                valid = false;
                //valCity.Style["display"] = "inline";
                this.PageTemplateASCX.displayCityVal();
                this.PageTemplateASCX.failedAddResults() ;
            }
            if (((TextBox)this.PageTemplateASCX.stateCritbox).Text == "")
            {
                valid = false;
                //valState.Style["display"] = "inline";
                this.PageTemplateASCX.displayStateVal();
                this.PageTemplateASCX.failedAddResults();
            }

            if (valid)
            {
                if (this.PageTemplateASCX.viewState != null)
                {
                    switch (this.PageTemplateASCX.viewState.ToString())
                    {
                        case "default": //default search
                            this.PageTemplateASCX.ds = //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                pxy.GetActivityAgencies(((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                            
                            if (this.PageTemplateASCX.ds != null)
                            {
                                ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource
                                ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                //((GridView)this.PageTemplateASCX.gridview).AutoGenerateColumns = false;
                                if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                {

                                    ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            { this.PageTemplateASCX.noSearchResults(); }
                            break;
                        case "2": //search 2
                            if (((TextBox)this.PageTemplateASCX.txtbox3control).Text != "")
                            {
                                //CREATE NECESSARY OBJECTS TO RUN METHOD//CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                ExperienceWebService2.Agencies agency = new Agencies();
                                agency.agenciesID = ((TextBox)this.PageTemplateASCX.txtbox3control).Text;

                                //REPLACE THIS METHOD //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds =
                                    pxy.GetActivities(agency, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                                
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {
                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;

                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                }
                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal3();
                                this.PageTemplateASCX.failedSearchResults();
                            }

                            break;
                        case "3": //search 3
                            if (((TextBox)this.PageTemplateASCX.txtbox6control).Text != ""
                                && ((TextBox)this.PageTemplateASCX.txtbox7control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                ExperienceWebService2.Activity activity = new Activity();
                                activity.activityType = ((TextBox)this.PageTemplateASCX.txtbox6control).Text;
                                activity.activityDay = ((TextBox)this.PageTemplateASCX.txtbox7control).Text;
                                //this.PageTemplateASCX.ds = null;
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                this.PageTemplateASCX.ds = pxy.FindActivities(activity, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                                
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                    for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                    {
                                        String image = "";
                                        image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                        ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                    }
                                }



                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal6();
                                this.PageTemplateASCX.displayVal7();
                                this.PageTemplateASCX.failedSearchResults();
                            }

                            break;
                        case "4": //search 4
                            if (((TextBox)this.PageTemplateASCX.txtbox9control).Text != ""
                                && ((TextBox)this.PageTemplateASCX.txtbox10control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                ExperienceWebService2.Activity activity = new Activity();
                                activity.activityType = ((TextBox)this.PageTemplateASCX.txtbox9control).Text;
                                activity.activityDay = ((TextBox)this.PageTemplateASCX.txtbox10control).Text;
                                //this.PageTemplateASCX.ds = null;

                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                //this.PageTemplateASCX.ds = pxy.FindActivitiesByVenue(activity, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                                //ViewState["dataSource"] = this.PageTemplateASCX.ds;
                                if (this.PageTemplateASCX.ds != null)
                                {
                                    
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                    for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                    {
                                        String image = "";
                                        image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                        ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                    }
                                }



                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal9();
                                this.PageTemplateASCX.displayVal10();
                                this.PageTemplateASCX.failedSearchResults();
                            }
                            break;
                        case "5": //search 4
                            if (((TextBox)this.PageTemplateASCX.txtbox12control).Text != ""
                                && ((TextBox)this.PageTemplateASCX.txtbox13control).Text != "")
                            {
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                ExperienceWebService2.Activity activity = new Activity();
                                activity.activityType = ((TextBox)this.PageTemplateASCX.txtbox12control).Text;
                                activity.activityDay = ((TextBox)this.PageTemplateASCX.txtbox13control).Text;
                                
                                //CHANGE THIS-----------------------------------------------------------------------------------------FILL
                                //this.PageTemplateASCX.ds = pxy.FindActivitiesByAgency(activity, ((TextBox)this.PageTemplateASCX.cityCritbox).Text, ((TextBox)this.PageTemplateASCX.stateCritbox).Text); //get appropriate dataset
                                
                                if (this.PageTemplateASCX.ds != null)
                                {
                                   // ViewState["dataSource"] = this.PageTemplateASCX.ds;
                                    ((GridView)this.PageTemplateASCX.gridview).DataSource = this.PageTemplateASCX.ds; //assign as datasource

                                    ((GridView)this.PageTemplateASCX.gridview).DataBind(); //databind it to gridview
                                    if (this.PageTemplateASCX.ds.Tables[0].Rows.Count > 0)
                                    {

                                        ((Button)this.PageTemplateASCX.addButton).Enabled = true;
                                    }
                                    else
                                    { this.PageTemplateASCX.noSearchResults(); }
                                    for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++)
                                    {
                                        String image = "";
                                        image = ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text;
                                        ((GridView)this.PageTemplateASCX.gridview).Rows[i].Cells[1].Text = "<img style=\"max-width:100px;max-height:100px;\" src=\"" + image + "\"/>";
                                    }
                                }



                                else
                                { this.PageTemplateASCX.noSearchResults(); }
                            }
                            else
                            {
                                this.PageTemplateASCX.displayVal12();
                                this.PageTemplateASCX.displayVal13();
                                this.PageTemplateASCX.failedSearchResults();
                            }
                            break;
                        default:
                            
                            break;
                    }
                }
            }
            else
            {
                this.PageTemplateASCX.viewState = "default";
            }
        }

        private void add(object sender, System.EventArgs e)
        {
            //((GridView)this.PageTemplateASCX.gridview).DataBind();
            this.PageTemplateASCX.reset();
            //((GridView)this.PageTemplateASCX.gridview).DataSource = ViewState["dataSource"];
            //((GridView)this.PageTemplateASCX.gridview).DataBind();
            
            int selectedCount = 0; //count number selected
            for (int i = 0; i < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; i++) //count
            {
                CheckBox selected = (CheckBox)((GridView)this.PageTemplateASCX.gridview).Rows[i].FindControl("chkSelect");
                if (selected.Checked) { selectedCount++; } //if selected, increment counter
            }
            if (selectedCount == 0) //if none selected
            {
                this.PageTemplateASCX.failedAddResults();
            }
            else //if at least one selected
            {
                //reloop through gridview
                for (int j = 0; j < ((GridView)this.PageTemplateASCX.gridview).Rows.Count; j++)
                {
                    //if the select box is checked..
                    CheckBox selected = (CheckBox)((GridView)this.PageTemplateASCX.gridview).Rows[j].FindControl("chkSelect");
                    if (selected.Checked == true)
                    {
                        //create a new object
                        ExperienceClass newExp = new ExperienceClass();
                        //initialize its properities to the record's values that was chosen
                        newExp.Agency_id = 1;

                        //if a vacation package exists
                        if (VacationPackage.getCustomerPackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString()) == null)
                        {
                            this.PageTemplateASCX.myPackage = new VacationPackage(); //if not, create a new one
                        }
                        else
                        {
                            //if yes, retrieve the package
                            this.PageTemplateASCX.myPackage = VacationPackage.getCustomerPackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString());
                        }
                        //finally, add the new object to the vacation package's appropriate list
                        this.PageTemplateASCX.myPackage.experienceArray.Add(newExp);
                    }
                }
                //update the vacation package in the database
                VacationPackage.updatePackage(this.PageTemplateASCX.objCookie.Values["LoginID"].ToString(), this.PageTemplateASCX.myPackage);
                this.PageTemplateASCX.successfulAddResults();
            }

        }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
        }
    }
}