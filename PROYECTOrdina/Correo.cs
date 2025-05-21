using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROYECTOrdina
{
    internal class Correo
    {

        public void Correoo(string error)
        {
            try
            {
                var fromAddress = new MailAddress("113069@alumnouninter.mx", "Sistema Exportar/Importar");
                var toAddress = new MailAddress("ad.sof_amaya@hotmail.com", "babvuc-0Wocce-nidmaw");

                const string subject = "Error en el sistema Exportar/Importar";
                string body = $"Se ha producido el siguiente error:\n\n{error}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.office365.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("113117@alumnouninter.mx", "20051219S0f")
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}


