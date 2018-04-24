using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelSiteLibrary;
using System.Data;
using TravelSite.ExperienceWebService;

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
                this.PageTemplateASCX.navDefaultHeading = "Default Search";
                this.PageTemplateASCX.navHeading2 = "Search 1";
                this.PageTemplateASCX.navHeading3 = "Search 2";
                this.PageTemplateASCX.navHeading4 = "Search 3";
                this.PageTemplateASCX.navHeading4 = "Search 4";
                this.PageTemplateASCX.cityCrit = "City";
                this.PageTemplateASCX.stateCrit = "State";
                this.PageTemplateASCX.txtbox1head = "Agency ID";
                this.PageTemplateASCX.txtbox2head = "Activity ID";
                this.PageTemplateASCX.txtbox3head = "Agency ID";
                this.PageTemplateASCX.txtbox4head = "Activity ID";
            }
                myaddButton = (Button)this.PageTemplateASCX.addButton;
                mysearchButton = (Button)this.PageTemplateASCX.searchButton;
                this.PageTemplateASCX.searchButtonClick += new EventHandler(search);
                this.PageTemplateASCX.addButtonClick += new EventHandler(add);
        }
        private void search2(object sender, System.EventArgs e) { this.PageTemplateASCX.navHeading2 = "GOT HERE"; }
        private void search(object sender, System.EventArgs e)
        {
            this.PageTemplateASCX.reset();
            ((GridView)this.PageTemplateASCX.gridview).DataSource = null;
            this.PageTemplateASCX.ds = null;
            ExperienceWebService.ActivitiesService pxy = new ActivitiesService();
            if (this.PageTemplateASCX.validateRequirements())
            {
                if (this.PageTemplateASCX.viewState != null)
                {
                    switch (this.PageTemplateASCX.viewState.ToString())
                    {
                        case "default":
                            this.PageTemplateASCX.ds = pxy.GetActivityAgencies(((TextBox)this.PageTemplateASCX.stateCritbox).Text, ((TextBox)this.PageTemplateASCX.cityCritbox).Text); //get appropriate dataset
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
                            break;
                        case "byAgency":
                            if (this.PageTemplateASCX.validate2())
                            {
                                ExperienceWebService.Agency agency = new Agency();
                                agency.Agency_id = Convert.ToInt32(((TextBox)this.PageTemplateASCX.txtbox1control).Text);

                                this.PageTemplateASCX.ds = pxy.GetActivities(agency, ((TextBox)this.PageTemplateASCX.stateCritbox).Text, ((TextBox)this.PageTemplateASCX.cityCritbox).Text); //get appropriate dataset
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
                            { this.PageTemplateASCX.noSearchResults(); }

                            break;
                        case "byActivity":
                            if (((TextBox)this.PageTemplateASCX.txtbox2control).Text != "")
                            {

                                ExperienceWebService.Activities activity = new Activities();
                                activity.Activity_type = ((TextBox)this.PageTemplateASCX.txtbox2control).Text;
                                activity.Activity_startDate = "02/02/2018";
                                activity.Activity_enddate = "02/03/2018";
                                this.PageTemplateASCX.ds = null;
                                this.PageTemplateASCX.ds = pxy.FindActivities(activity, ((TextBox)this.PageTemplateASCX.stateCritbox).Text, ((TextBox)this.PageTemplateASCX.cityCritbox).Text); //get appropriate dataset
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
                            { this.PageTemplateASCX.noSearchResults(); ((Control)this.PageTemplateASCX.txtbox2validator).Visible = false; }
                            break;
                        case "byVenue":

                            break;
                        case "byAgencyAndActivity":

                            break;
                        default:
                            this.PageTemplateASCX.ds = pxy.GetActivityAgencies(((TextBox)this.PageTemplateASCX.stateCritbox).Text, ((TextBox)this.PageTemplateASCX.cityCritbox).Text); //get appropriate dataset
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
            this.PageTemplateASCX.navDefaultHeading = "yasssssss";
        }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
        }
    }
}