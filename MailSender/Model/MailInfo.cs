using System.Collections.Generic;

namespace MailSender.Model
{
    public class MailInfo
    {
        public List<string> DestinationEmails { get; set; }
        public List<string> CCDestinationEmails { get; set; }     //Bilgilendirilecek e-posta adresleri
        public List<string> BCCDestinationEmails { get; set; }    //Gizli olarak eklenecek e-posta adresleri
        public string Topic { get; set; }
        public string Context { get; set; }
        public List<string> Attachements { get; set; }
    }
}
