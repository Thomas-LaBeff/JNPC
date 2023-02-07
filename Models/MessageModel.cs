using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Church_App.Models
{
    public class MessageModel
    {
        [Required]
        public string ServiceDate { get; set; }
        [Required]
        public string MessageTopic { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required (ErrorMessage = "If entering new record, enter '-1'.")]
        public int Message_ID { get; set; }

        public string Video { get; set; }

        public MessageModel()
        {
            ServiceDate = "";
            MessageTopic = "";
            MessageTitle = "";
            Message_ID = -1;
            Video = "\\";
        }

        public MessageModel(string serviceDate, string messageTopic, string messageTitle, int message_ID, string video)
        {
            ServiceDate = serviceDate;
            MessageTopic = messageTopic;
            MessageTitle = messageTitle;
            Message_ID = message_ID;
            Video = video;
        }
    }
}