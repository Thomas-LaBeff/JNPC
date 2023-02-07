using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Church_App.Models
{
    public class ContactDetailsModel
    {
        
        public string Contact_ID { get; set; }
        
        public string Date_Of_Contact { get; set; }
        
        public string Topic_Discussed { get; set; }
       
        public string Response { get; set; }

        public int CD_ID { get; set; }

        public ContactDetailsModel()
        {
            Contact_ID = "";
            Date_Of_Contact = "";
            Topic_Discussed = "";
            Response = "";
            CD_ID = -1;
        }

        public ContactDetailsModel(string contact_id, string date_of_contact, string topic_discussed, string response, int cd_id)
        {
            Contact_ID = contact_id;
            Date_Of_Contact = date_of_contact;
            Topic_Discussed = topic_discussed;
            Response = response;
            CD_ID = cd_id;
        }
    }
}