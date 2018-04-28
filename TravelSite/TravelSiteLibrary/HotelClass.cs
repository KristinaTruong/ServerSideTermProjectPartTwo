using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSiteLibrary
{
    [Serializable]
    public class HotelClass
    {
    public int ID { get; set; }

    public string hotel { get; set; }

    public int room { get; set; }

    public string customer { get; set; }

   public string reservation { get; set; }

    private string travelSiteID { get; set; }

    private string TravelSitePassword { get; set; }
    }
}
