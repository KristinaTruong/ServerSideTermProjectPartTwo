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

namespace TravelSiteLibrary
{
    public class VacationPackage
    {
        public static DBConnect objDB = new DBConnect();
        public CustomerClass[] customerArray { get; set; }
        public FlightClass[] flightArray { get; set; }

        public ExperienceClass[] experienceArray { get; set; }

        public HotelClass[] hotelArray { get; set; }

        //serialize a customer object
        public static byte[] serializeVacationPackage(VacationPackage package)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, package);
            byte[] myArray = memStream.ToArray();

            return myArray;
        }

        //deserializes a customer, and returns it as a customerClass object
        private static VacationPackage deserializeVacationPackage(byte[] customer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            MemoryStream newMemStream = new MemoryStream(customer);
            VacationPackage deserializedPackage = (VacationPackage)deserializer.Deserialize(newMemStream);
            return deserializedPackage;

        }

        //returns customer's password (deserialized) when a loginID is inserted
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

        public static DataSet getCustomerInfo(String loginID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FindTravelCustomer";
            objCommand.Parameters.AddWithValue("loginID", loginID);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public static Boolean addExperience(ExperienceClass exp, String login)
        {
            VacationPackage custPackage = VacationPackage.getCustomerPackage(login);
            for (int i = 0; i < gvAvailable.Rows.Count; i++)
            {
                CheckBox selected = (CheckBox)gvAvailable.Rows[i].FindControl("chkSelect");
                if (selected.Checked)
                {
                    custPackage.experienceArray.
                    }
            }
        }
    }
}
