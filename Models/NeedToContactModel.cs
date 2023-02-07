using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Church_App.Models
{
    public class NeedToContactModel
    {
        public string Contact_ID { get; set; }
        public string Name { get; set; }

        public string Recent_Contact { get; set; }

        public string Topic_Discussed { get; set; }

        public string Response { get; set; }


        public NeedToContactModel()
        {
            Contact_ID = "";
            Name = "";
            Recent_Contact = "";
            Topic_Discussed = "";
            Response = "";
        }

        public NeedToContactModel(string contact_id, string name, string recent_contact, string topic_discussed, string response)
        {
            Contact_ID = contact_id;
            Name = name;
            Recent_Contact = recent_contact;
            Topic_Discussed = topic_discussed;
            Response = response;
        }
    }
}