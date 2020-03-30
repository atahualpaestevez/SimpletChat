using System;
using System.Collections.Generic;
using System.Text;

namespace SampleChat.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
        public string UserId { get; set; }
       
    }
}
