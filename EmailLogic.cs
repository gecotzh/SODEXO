using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Sodexo.EPedidos.Extension.Logica
{
    public class EmailLogic
    {
        public String from { get; set; }
        public String Password { get; set; }
        public int Port { get; set; }
        public SmtpClient client { get; set; }
        //public bool enabledSSL { get; set; }


        public EmailLogic(string from,string password, SmtpClient client,int port, bool enabledSSL)
        {
            var EmailProdEnv = bool.Parse(ConfigurationManager.AppSettings["EmailProdEnv"]);

            this.from = ConfigurationManager.AppSettings["clientEmailSTMP"].ToString();
            var Password = ConfigurationManager.AppSettings["clientPassSTMP"] ?? "";
            this.client = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["clientHostSTMP"].ToString());
            this.client.Port = int.Parse(ConfigurationManager.AppSettings["clientPortSTMP"]);
            this.client.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["clientEnabledSSL"]);

            if (EmailProdEnv)
            {
                this.client.UseDefaultCredentials = true;
            }
            else
            {
                this.client.Credentials = new NetworkCredential(from, Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
            }
        }

        public String SendMail(String asunto, String[] EmailTo, String[] CopyTo, String Mensaje)
        {
            try
            {
                // string Themessage = String.Empty;
                String Asunto = asunto;

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(from);

                foreach (var to in EmailTo)
                {
                    mm.To.Add(to);
                }
                foreach (var copy in CopyTo)
                {
                    mm.CC.Add(copy);
                } 
                mm.Subject = Asunto;
                mm.Body = Mensaje;
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                client.Send(mm);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public String SendMailConfirmarCuenta(String asunto, String Email, String Mensaje)
        {
            try
            {
               // string Themessage = String.Empty;
                String Asunto = asunto;

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(from);
                mm.To.Add(Email);
                mm.Subject = Asunto;
                mm.Body = Mensaje;
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                
                client.Send(mm);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

    }
}