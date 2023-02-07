using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Church_App.Data
{
    internal class Admin_MessageDAO
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public List<MessageModel> FetchAll()
        {
            List<MessageModel> returnList = new List<MessageModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Pastoral.Message ORDER BY ServiceDate Desc";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a new message object.  Add it to the list to return.
                        MessageModel messages = new MessageModel();
                        messages.ServiceDate = (reader.GetDateTime(0)).ToString();
                        messages.MessageTopic = reader.GetString(1);
                        messages.MessageTitle = reader.GetString(2);
                        messages.Message_ID = reader.GetInt32(3);
                        messages.Video = reader.GetString(4);

                        returnList.Add(messages);
                    }
                }
            }

            return returnList;
        }
    }
}