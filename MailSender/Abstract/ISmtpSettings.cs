using System.Net.Mail;

namespace MailSender.Abstract
{
    public interface ISmtpSettings
    {
        SmtpClient GetSmtpClientInfo();
        string GetSenderMailInfo();
        string GetSenderTitleInfo();
    }
}
