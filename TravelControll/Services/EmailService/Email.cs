using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace TravelControll.Services.EmailService
{
    public class Email
    {
        public string Provedor { get;private set; }
        public string UserName { get; private set; }
        public string PassWrod { get; private set; }
        public Email(string provedor, string userName, string passWrod)
        {
            Provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            UserName = userName ?? throw new ArgumentNullException(nameof(provedor));
            PassWrod = passWrod ?? throw new ArgumentNullException(nameof(provedor));
        }
        public void SendEmail(List<string> emailsTo,string subject,string body,List<string> attachments)
        {
            var message = PrepareteMessage(emailsTo,subject, body, attachments);
            SendEmailBySmtp(message);

        }
        private MailMessage PrepareteMessage(List<string> emailsTo, string subject, string body, List<string> attachments)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(UserName);
            foreach(var email in emailsTo)
            {
                if (ValidateEmail(email))
                {
                    mail.To.Add(email);
                }               
            }
            mail.Subject= subject;
            mail.Body= body;
            mail.IsBodyHtml= true;
            foreach(var file in attachments)
            {
                var data = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                mail.Attachments.Add(data);
            }
            return mail;
        }
        private bool ValidateEmail(string email)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expression.IsMatch(email))
            {
                return true;
            }
            return false;
        }
        private void SendEmailBySmtp(MailMessage message)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Provedor;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(UserName, PassWrod);
            smtpClient.Send(message);
            smtpClient.Dispose();
        }
    }
}
