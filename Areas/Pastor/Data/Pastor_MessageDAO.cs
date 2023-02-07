using Church_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Church_App.Data
{
    internal class Pastor_MessageDAO
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

        internal int Delete(int id)
        {
            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = sqlQuery = "DELETE FROM Pastoral.Message WHERE Message_ID = @Message_ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Message_ID", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }
        }

        internal List<MessageModel> SearchFields(string ServiceDate, string MessageTopic, string MessageTitle, string Message_ID, string Video)
        {
            List<MessageModel> returnList = new List<MessageModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                string tbv = "";
                string searchQuery = " WHERE ";

                


                if (ServiceDate.Length > 0)
                {
                    if (searchQuery.Length > 7)
                    {
                        searchQuery = searchQuery + " AND ";
                    }
                    tbv = "ServiceDate = @ServDate";
                    searchQuery += tbv;
                }

                if (MessageTopic.Length > 0)
                {
                    if (searchQuery.Length > 7)
                    {
                        searchQuery = searchQuery + " AND ";
                    }
                    tbv = "MessageTopic = @MessTopic";
                    searchQuery += tbv;
                }

                if (MessageTitle.Length > 0)
                {
                    if (searchQuery.Length > 7)
                    {
                        searchQuery = searchQuery + " AND ";
                    }
                    tbv = "MessageTitle = @MessTitle";
                    searchQuery += tbv;
                }

                

                sqlQuery = "SELECT * FROM Pastoral.Message " + searchQuery + " ORDER BY ServiceDate DESC;";
                if(searchQuery.Length > 7)
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.Add("@ServDate", System.Data.SqlDbType.NVarChar).Value = ServiceDate;
                    command.Parameters.Add("@MessTopic", System.Data.SqlDbType.NVarChar).Value = MessageTopic;
                    command.Parameters.Add("@MessTitle", System.Data.SqlDbType.NVarChar).Value = MessageTitle;
                    //command.Parameters.Add("@Mess_ID", System.Data.SqlDbType.Int).Value = Message_ID;
                    command.Parameters.Add("@Vid", System.Data.SqlDbType.NVarChar).Value = Video;

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

                            returnList.Add(messages);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You didn't enter any data in the textboxes, so there will not be any results.  Please restart your search and enter data in any combination of text boxe.");
                }
            }
            return returnList;
            
        }

        public MessageModel FetchOne(int Message_ID)
        {


            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Pastoral.Message WHERE Message_ID = @Mess_ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Mess_ID", System.Data.SqlDbType.Int).Value = Message_ID;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                MessageModel message = new MessageModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a new message object.  Add it to the list to return.

                        message.ServiceDate = (reader.GetDateTime(0)).ToString();
                        message.MessageTopic = reader.GetString(1);
                        message.MessageTitle = reader.GetString(2);
                        message.Message_ID = reader.GetInt32(3);
                        message.Video = reader.GetString(4);
                    }
                }
                return message;
            }
        }


        public int CreateOrUpdate(MessageModel messageModel)
        {
            // if Message_ID <= 1 then create.
            // if Messsge_ID > 1 then update is meant.

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (messageModel.Message_ID <= 0)
                {
                    sqlQuery = "INSERT INTO Pastoral.Message Values(@ServiceDate, @MessageTopic, @MessageTitle, @Vid)";
                }
                else
                {
                    // update
                    sqlQuery = "UPDATE Pastoral.Message SET ServiceDate = @ServiceDate, MessageTopic = @MessageTopic, MessageTitle = @MessageTitle, Video = @Vid WHERE Message_ID = @Message_ID";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ServiceDate", System.Data.SqlDbType.VarChar).Value = messageModel.ServiceDate;
                command.Parameters.Add("@MessageTopic", System.Data.SqlDbType.VarChar, 50).Value = messageModel.MessageTopic;
                command.Parameters.Add("@MessageTitle", System.Data.SqlDbType.VarChar, 100).Value = messageModel.MessageTitle;
                command.Parameters.Add("@Message_ID", System.Data.SqlDbType.Int).Value = messageModel.Message_ID;
                command.Parameters.Add("@Vid", System.Data.SqlDbType.VarChar, 500).Value = messageModel.Video;

                connection.Open();
                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }


    }
}