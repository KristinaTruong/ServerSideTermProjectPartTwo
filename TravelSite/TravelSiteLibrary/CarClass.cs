using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSiteLibrary.CarWebServiceClass2;

namespace TravelSiteLibrary
{
    [Serializable]
    public class CarClass
    {
        public String CarID { get; set; }
        public String Cost  {get;set;}
        public int agencyID { get; set; }
        public Boolean reserved;



         public CarClass()
        {
            reserved = false;
        }

        public CarClass(int id)
        {
            agencyID = id;
            reserved = false;
        }
    }

}
