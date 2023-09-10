using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public MessageType MessageType { get; set; }
        public string Text { get; set; }
        public string MessageId { get; set; }
        public string PhoneNumber { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int? Author { get; set; }
        public int? Addressee { get; set; }
        public DateTime SendDate { get; set; }
    }
}
