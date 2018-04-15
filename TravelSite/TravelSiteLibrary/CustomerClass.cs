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
        public String customerAddress { get; set; }
        public String customerEmail { get; set; }
        public String customerPayment { get; set; }
        public String customerPassword { get; set; }
        
        public CustomerClass()
        {

        }
        public CustomerClass(String login, String name,
            String phone, String address,
            String email, String payment, 
            String password)
        {
            customerLoginID = login;
            customerName = name;
            customerPhone = phone;
            customerAddress = address;
            customerEmail = email;
            customerPayment = payment;
            customerPassword = password;
        }
    }

}

