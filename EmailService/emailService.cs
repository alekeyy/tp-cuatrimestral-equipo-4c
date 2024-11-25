using System;
using System.Net;
using System.Net.Mail;

namespace EmailService
{
    public class emailService
    {
        private MailMessage email;
        private SmtpClient server;

        public emailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("f7f941c1b24bb7", "9f6e2a6725418b");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("braianpirelli@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>" + cuerpo + "</h1>";
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
