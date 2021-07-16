using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }

        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        public bool IsTrash { get; set; }

    }
}
