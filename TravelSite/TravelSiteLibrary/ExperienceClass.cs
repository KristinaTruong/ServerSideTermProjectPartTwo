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
        public String Agency_id { get; set; }
         //ACTIVITY
        public String Activity_id { get; set; }


        //CUSTOMER

        private String SiteID;
        private String SitePassword;
        public Boolean reserved;

        public ExperienceClass()
        {
            /*
            agency = new Agency();
            activity = new Activities();
            customer = new Customer();*/
            SiteID = "";
            SitePassword = "";
            reserved = false;
        }

        public ExperienceClass(String agencyID, String agencyName, String activityID, decimal activityCost
            , String activityType)
        {
            Agency_id = agencyID;
            Activity_id = activityID;
            //ADD CUSTOMER ATTRIBUTES
            SiteID = "";
            SitePassword = "";
            reserved = false;
        }
    }
}
