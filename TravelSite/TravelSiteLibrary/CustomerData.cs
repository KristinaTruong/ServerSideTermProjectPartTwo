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

        //serialize a customer object
        private static byte[] serializeCustomer(CustomerClass customer)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, customer);
            byte[] myArray = memStream.ToArray();

            return myArray;
        }

        //deserializes a customer, and returns it as a customerClass object
        private static CustomerClass deserializeCustomer(byte[] customer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream newMemStream = new MemoryStream(customer);
            CustomerClass deserializedCustomer = (CustomerClass)deserializer.Deserialize(newMemStream);
            return deserializedCustomer;

        }

        //deserializes a customer password field, and returns the password as a string
        public static String deserializeCustomerPassword(byte[] customer)
        {
            CustomerClass deserializedCustomer = deserializeCustomer(customer);
            return deserializedCustomer.customerPassword;

        }

        //returns customer's password (deserialized) when a loginID is inserted
        public static String getCustomerPassword(String loginID)
        {
            DataSet customerInfo = getCustomerInfo(loginID);
            byte[] password = (byte[])customerInfo.Tables[0].Rows[0][5];
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream newMemStream = new MemoryStream(password);

            CustomerClass deserializedCustomer = (CustomerClass)deserializer.Deserialize(newMemStream);
            return deserializedCustomer.customerPassword;

        }

        //checks if the loginID already exists, returns true if it does
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

        //returns a dataset with the customer record associated with the inserted loginID
        public static DataSet getCustomerInfo(String loginID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FindTravelCustomer";
            objCommand.Parameters.AddWithValue("loginID", loginID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        //creates a customer record
        public static void createCustomer(CustomerClass customer)
        {
            if (checkIfLoginExists(customer) == false)
                //checks if customer login already exists, 
                //if not already exists, continue to create the record
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CreateTravelCustomer";
                objCommand.Parameters.AddWithValue("loginID", customer.customerLoginID);
                objCommand.Parameters.AddWithValue("name", customer.customerName);
                objCommand.Parameters.AddWithValue("address", customer.customerAddress);
                objCommand.Parameters.AddWithValue("email", customer.customerEmail);
                objCommand.Parameters.AddWithValue("phone", customer.customerPhone);
                objCommand.Parameters.AddWithValue("password", serializeCustomer(customer));
                objCommand.Parameters.AddWithValue("payment", customer.customerPayment);
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            }

        }
    }
}
