using MailSender.Model;

namespace MailSender.Concrete
{
    public class MailEngine
    {
        public MailSendResult MailGonder(MailInfo mailgBilgi)
        {
            MailSender mailGonderen = new MailSender(new MailProcessor(), new SmtpSetttings());
            return mailGonderen.Send(mailgBilgi);
        }
    }
}
