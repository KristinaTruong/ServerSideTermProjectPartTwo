using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;
using System.Data.SqlClient;

namespace TravelSiteLibrary
{
    public class CustomerData
    {
        public static DBConnect objDB = new DBConnect();

        public static byte[] serializeCustomer(CustomerClass customer)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, customer);
            byte[] myArray = memStream.ToArray();

            return myArray;
        }

        public static CustomerClass deserializeCustomer(byte[] customer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream newMemStream = new MemoryStream(customer);

            CustomerClass deserializedCustomer = (CustomerClass)deserializer.Deserialize(newMemStream);
            return deserializedCustomer;

        }

        public static Boolean checkIfLoginExists(CustomerClass customer)
        {
            //make sure login is not null or an empty string
            if (customer.customerLoginID != null || customer.customerLoginID.Trim() != "")
            {
                //execute the stored procedure
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "FindTravelCustomer";
                objCommand.Parameters.AddWithValue("loginID", customer.customerLoginID);

                //if returned dataset row count is more than one, the user exists
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                //if 0 rows in dataset, user doesn't exist
                return false;
            }
            //if login is null or empty, return false
            return false;
        }

        public static DataSet getCustomerInfo(CustomerClass customer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FindTravelCustomer";
            objCommand.Parameters.AddWithValue("loginID", customer.customerLoginID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }
    }
}
