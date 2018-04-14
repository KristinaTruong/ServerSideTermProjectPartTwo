using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSiteLibrary
{
    [Serializable]
    public class CustomerClass
    {
        public String customerLoginID { get; set; }
        public String customerName { get; set; }
        public String customerPhone { get; set; }
        public String customerEmail { get; set; }
        public String customerPayment { get; set; }
        public String customerPassword { get; set; }

    }

}

