using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWebsite.Helpers
{
    public class Flash
    {
        public Flash(MessageType type, string msg)
        {
            this.MessageType = type;
            this.Message = msg;
        }

        public string Message
        {
            get;
            set;
        }

        public MessageType MessageType
        {
            get;
            set;
        }
    }
}