using System.Net;
using System.Net.Mail;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class SmtpSetttings :ISmtpSettings
    {
        private SmtpSetting _smtpSetting;
        private SmtpSetting GetSmtpSettings()
        {
            _smtpSetting = new SmtpSetting();
            _smtpSetting.Host = "smtp.gmail.com";
            _smtpSetting.Port = 587;
            _smtpSetting.UserName = "infocartender@gmail.com";
            _smtpSetting.Password = "pwqmthuvomlowtfd";
            _smtpSetting.UseSSL = true;
            _smtpSetting.Title = "Test Kişisi";

            return _smtpSetting;
        }



        public SmtpClient GetSmtpClientInfo()
        {
            SmtpSetting smtpSettings = GetSmtpSettings();
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpSettings.Host;
            smtpClient.Port = smtpSettings.Port;
            smtpClient.EnableSsl = smtpSettings.UseSSL;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpSettings.UserName,smtpSettings.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Timeout = 3000;

            return smtpClient;
        }

        public string GetSenderMailInfo()
        {
            return _smtpSetting.UserName;
        }

        public string GetSenderTitleInfo()
        {
            return _smtpSetting.Title;
        }
    }
}
