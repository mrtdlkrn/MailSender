using MailSender.Model;

namespace MailSender.Abstract
{
    public interface IMailProcessor
    {
        void SendMail(MailInfo mailInfo,ISmtpSettings smtpSettings);
    }
}