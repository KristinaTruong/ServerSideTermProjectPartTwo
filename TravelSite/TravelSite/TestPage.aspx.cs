using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelSite
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageTemplateASCX.title = "Test Page";
            this.PageTemplateASCX.navDefaultHeading = "Default Search";
            this.PageTemplateASCX.navHeading2 = "Search By Air Carrier";
            this.PageTemplateASCX.navHeading3 = "Search By Air Carrier";
            this.PageTemplateASCX.navHeading4 = "Search By Air Carrier";
            this.PageTemplateASCX.navHeading4 = "Search By Air Carrier";

        }
    }
}