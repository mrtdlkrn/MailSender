using System.Net.Mail;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class MailProcessor : IMailProcessor
    {
        public void SendMail(MailInfo mailInfo, ISmtpSettings smtpSettings)
        {
            SmtpClient smtpClient = smtpSettings.GetSmtpClientInfo();
            MailMessage email = new MailMessage();

            //mail gonderecek hesap.
            email.From = new MailAddress(smtpSettings.GetSenderMailInfo(),smtpSettings.GetSenderTitleInfo()); 

            //mail gonderilecek e-posta adresleri.
            mailInfo.DestinationEmails.ForEach(x =>{email.To.Add(x);});

            //Bilgilendirme olarak eklenecek mail adresleri.
            mailInfo.CCDestinationEmails?.ForEach(x =>{email.CC.Add(x);});

            //Gizli olarak eklenecek mail adresleri.
            mailInfo.BCCDestinationEmails?.ForEach(x =>{email.Bcc.Add(x);});

            //mailin konusu.
            email.Subject = mailInfo.Topic;

            //mail icerigi html olarak gonderilsin.
            email.IsBodyHtml = true;

            //mail icerigi.
            email.Body = mailInfo.Context;
            // ekleri temizledik.
            email.Attachments.Clear();

            //mail ek dosyalari eklendi.
            mailInfo.Attachements?.ForEach(x =>{email.Attachments.Add(new Attachment(x));});

            //Mail gonderiliyor.
            smtpClient.Send(email);
        }
    }
}
