using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using TravelSiteLibrary.CarWebServiceClass2;
using TravelSiteLibrary;

namespace TravelSiteLibrary
{
    [Serializable]
    public class VacationPackage
    {

        public String loginID { get; set; }
        public String purchaseDate { get; set; }
        public double salesTotal { get; set; }
        public static DBConnect objDB = new DBConnect();

        //AMENITITES LIST ---------------------------------------------------------------
        public List<ExperienceClass> experienceArray { get; set; }
        
        public List<CarClass> carArray { get; set; }
        public List<FlightClass> flightArray { get; set; }
        public List<HotelClass> hotelArray { get; set; }
        
        //--------------------------------------------------------------------------------

        public VacationPackage()
        {
            experienceArray = new List<ExperienceClass>();
            /*
            carArray = new List<CarClass>();
            flightArray = new List<FlightClass>();
            hotelArray = new List<HotelClass>();
            */
        }
        //serialize a vacation package object
        private static byte[] serializeVacationPackage(VacationPackage package)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, package);
            byte[] myArray = memStream.ToArray();

            return myArray;
        }

        //deserializes a vacation package, and returns it as a VacationPackage object
        private static VacationPackage deserializeVacationPackage(byte[] customer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream newMemStream = new MemoryStream(customer);
            VacationPackage deserializedPackage = (VacationPackage)deserializer.Deserialize(newMemStream);
            return deserializedPackage;

        }

        //get a customer's information
        private static DataSet getCustomerInfo(String loginID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FindTravelCustomer";
            objCommand.Parameters.AddWithValue("loginID", loginID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        //returns vacation package when loginID is provided
        public static VacationPackage getCustomerPackage(String loginID)
        {
            if (getCustomerInfo(loginID).Tables[0].Rows.Count != 0)
            {
                DataSet customerInfo = getCustomerInfo(loginID);
                if ((customerInfo.Tables[0].Rows[0][8]) != DBNull.Value)
                {
                    byte[] package;

                    package = (byte[])customerInfo.Tables[0].Rows[0][8];

                    if (package.Length != 0)
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        MemoryStream newMemStream = new MemoryStream(package);

                        VacationPackage vacationPackage = (VacationPackage)deserializer.Deserialize(newMemStream);
                        return vacationPackage;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;



            }
            else { return null; }
        }


        public static void updatePackage(String login, VacationPackage package)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, package);
            byte[] myArray = memStream.ToArray();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateVacationPackage";
            objCommand.Parameters.AddWithValue("login", login);
            objCommand.Parameters.AddWithValue("package", myArray);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

        }


        public static DataSet myTrips(String login)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getMyTrips";
            objCommand.Parameters.AddWithValue("login", login);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public void purchasePackage()
        {
            /*
            //Book experience objects
            for (int i = 0; i < experienceArray.Count; i++)
            {
                ExperienceWebServiceClass.ActivitiesService expPxy = new ExperienceWebServiceClass.ActivitiesService();
                Boolean reserved = expPxy.Reserve(experienceArray[i].agency, experienceArray[i].activity, experienceArray[i].customer, "", "");
                if (reserved)
                {
                    experienceArray.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            */

        }

        public static DataSet getPastTrips(String login)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPastTrips";
            objCommand.Parameters.AddWithValue("login", login);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;
        }
        public static DataSet getTripInfo(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetTripInfo";
            objCommand.Parameters.AddWithValue("vacationID", id);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;
        }

    }
}
