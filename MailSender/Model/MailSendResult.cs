using System.Collections.Generic;
using System.Linq;

namespace MailSender.Model
{
    public class MailSendResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public string ErrorsStr
        {
            get { return Errors.Aggregate((x,y)=>x+"\r\n"+y); }
            private set { }
        }
    }
}
