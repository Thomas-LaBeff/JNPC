using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Configuration;

namespace Church_App.Data
{
    internal class Contact_Details_DAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<ContactDetailsModel> FetchResult()
        {
            List<ContactDetailsModel> returnList = new List<ContactDetailsModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Pastoral.Contact_Details ORDER BY Date_Of_Contact Desc";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContactDetailsModel contactDetails = new ContactDetailsModel();
                        contactDetails.Contact_ID = reader.GetString(0);
                        contactDetails.Date_Of_Contact = (reader.GetDateTime(1)).ToString();
                        contactDetails.Topic_Discussed = reader.GetString(2);
                        contactDetails.Response = reader.GetString(3);
                        contactDetails.CD_ID = reader.GetInt32(4);

                        returnList.Add(contactDetails);
                    }
                }
            }


            return returnList;
        }

        public List<NeedToContactModel> NeedToContact()
        {
            List<NeedToContactModel> returnList = new List<NeedToContactModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT recent.Contact_ID AS 'Contact ID', CONCAT(FirstName, LastName) AS 'Name', recent.Most_Resent_Contact AS 'Last Contact', cd.Topic_Discussed AS 'Topic Discussed', cd.Response AS 'Response' FROM Pastoral.Contact_Details cd JOIN Admin.Contact c ON cd.Contact_ID = c.Contact_ID JOIN(SELECT Contact_ID, MAX(Date_Of_Contact) AS Most_Resent_Contact FROM Pastoral.Contact_Details GROUP BY Contact_ID) recent ON cd.Contact_ID = recent.Contact_ID AND cd.Date_Of_Contact = recent.Most_Resent_Contact WHERE recent.Most_Resent_Contact < DATEADD(DD, -14, GETDATE()) AND Active = 1 ORDER BY cd.Date_Of_Contact DESC";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NeedToContactModel contactDetails = new NeedToContactModel();
                        contactDetails.Contact_ID = reader.GetString(0);
                        contactDetails.Name = reader.GetString(1);
                        contactDetails.Recent_Contact = (reader.GetDateTime(2)).ToString();
                        contactDetails.Topic_Discussed = reader.GetString(3);
                        contactDetails.Response = reader.GetString(4);

                        returnList.Add(contactDetails);
                    }
                }
            }


            return returnList;
        }

    }
}