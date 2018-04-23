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

namespace TravelSiteLibrary
{
    public class VacationPackage
    {
        public String loginID { get; set; }
        public String purchaseDate { get; set; }
        public double salesTotal { get; set; }
        public static DBConnect objDB = new DBConnect();

        //AMENITITES LIST ---------------------------------------------------------------
        public List<ExperienceClass> experienceArray { get; set; }

        //--------------------------------------------------------------------------------

        public List<CarWebServiceClass2.Car> carArrayNew { get; set; }
        public List<HotelClass> hotelArray { get; set; }

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
            DataSet customerInfo = getCustomerInfo(loginID);
            byte[] package = (byte[])customerInfo.Tables[0].Rows[0][8];

            if (package != null || package.Length != 0)
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

        public Boolean checkPackage()
        {
            return false;
        }


        public void purchasePackage()
        {
            if (checkPackage())
            {
                for (int i = 0; i < experienceArray.Count; i++)
                {
                    ExperienceWebServiceClass.ser
                }
            }
        }


    }
}
