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
                Control addButton = this.PageTemplateASCX.addButton;
                Control searchButton = this.PageTemplateASCX.searchButton;
            }
            this.PageTemplateASCX.searchButtonClick += new EventHandler(changeTest);
            this.PageTemplateASCX.addButtonClick += new EventHandler(changeTest);
        }

        private void changeTest(object sender, System.EventArgs e)
        {
            this.PageTemplateASCX.title = "YEYEYYEYYEYEYE";
        }

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
        }
    }
}