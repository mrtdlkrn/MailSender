using System;
using System.Collections.Generic;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    public class MailSender
    {
        private IMailProcessor _mailProcessor;
        private ISmtpSettings _smtpSettings;
        public MailSender(IMailProcessor mailProcessor, ISmtpSettings smtpSettings)
        {
            _mailProcessor = mailProcessor;
            _smtpSettings = smtpSettings;
        }
        public MailSendResult Send(MailInfo mailInfo)
        {
            MailSendResult mailSendResult = new MailSendResult();
            mailSendResult.Errors = new List<string>();
            try
            {
                //Bilgi kontrol et hataliysa logla ve basarisiz don.
                mailSendResult = InfoValidation(mailInfo, mailSendResult);
                if (!mailSendResult.Success)
                    return mailSendResult;

                //mail gonderimi yap. exception alinmazsa basarilidir.
                _mailProcessor.SendMail(mailInfo, _smtpSettings);

                //Gönderim başarılı
                mailSendResult.Success = true;
                return mailSendResult;

            }
            catch (Exception ex)
            {
                mailSendResult.Errors.Add(ex.Message);
                mailSendResult.Success = false;
                return mailSendResult;
            }

        }

        private MailSendResult InfoValidation(MailInfo mailInfo, MailSendResult mailSendResult)
        {
            mailSendResult.Success = true;
            return mailSendResult;
        }
    }
}
