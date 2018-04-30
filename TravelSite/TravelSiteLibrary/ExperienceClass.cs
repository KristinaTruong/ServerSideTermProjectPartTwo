using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelSiteLibrary
{
    [Serializable]
    public class ExperienceClass
    {
        /*
        public ExperienceWebServiceClass.Agency agency { get; set; }
        public ExperienceWebServiceClass.Activities activity { get; set; }
        public ExperienceWebServiceClass.Customer customer { get; set; }
        */

        //fields needed to create the above class objects for the web methods to work!

        //AGENCY
        public int Agency_id { get; set; }
        public String Agency_name { get; set; }

        //ACTIVITY
        public int Activity_id { get; set; }
        public decimal Activity_cost { get; set; }
        public String Activity_type { get; set; }


        //CUSTOMER

        private String SiteID;
        private String SitePassword;


        public ExperienceClass()
        {
            /*
            agency = new Agency();
            activity = new Activities();
            customer = new Customer();*/
            SiteID = "";
            SitePassword = "";
        }

        public ExperienceClass(int agencyID, String agencyName, int activityID, decimal activityCost
            , String activityType)
        {
            Agency_id = agencyID;
            Agency_name = agencyName;
            Activity_id = activityID;
            Activity_cost = activityCost;
            Activity_type = activityType;
            //ADD CUSTOMER ATTRIBUTES
            SiteID = "";
            SitePassword = "";
        }
    }
}
