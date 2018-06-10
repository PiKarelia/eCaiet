using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.DB
{
    public class ChatRecords
    {
        public Guid Guid { get; set; }
        public Guid SenderGuid { get; set; }
        public User Sender { get; set; }
        public Guid ReceiverGuid { get; set; }
        public User Receiver { get; set; }
        public DateTime SendTime { get; set; }
        public string Content{ get; set; }
}
}
