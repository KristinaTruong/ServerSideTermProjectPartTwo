using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSiteLibrary.ExperienceWebServiceClass;

namespace TravelSiteLibrary
{
    public class ExperienceClass
    {
        public ExperienceWebServiceClass.Agency agency { get; set; }
        public ExperienceWebServiceClass.Activities activity { get; set; }
        public ExperienceWebServiceClass.Customer customer { get; set; }
        String SiteID;
        String SitePassword;
        public ExperienceClass()
        {
            SiteID = "";
            SitePassword = "";
        }

        public ExperienceClass(int agencyID, String agencyName, int activityID, decimal activityCost
            ,String activityType)
        {
            agency.Agency_id = agencyID;
            agency.Agency_name = agencyName;
            activity.Activity_id = activityID;
            activity.Activity_cost = activityCost;
            activity.Activity_type = activityType;
            SiteID = "";
            SitePassword = "";
        }
    }
}
