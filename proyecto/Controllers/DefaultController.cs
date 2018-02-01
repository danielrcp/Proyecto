using Model;
using proyecto.App_Start;
using proyecto.ViewModels;
using Rotativa.MVC;
using System;
using System.Net.Mail;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class DefaultController : Controller
    {
        private Usuario usuario = new Usuario();
        public ActionResult Index() => View(usuario.Obtener(FrontOfficeAppStart.UsuarioVisualizando(), true));

        public JsonResult EnviarCorreo(ContactoViewModel model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var _usuario = usuario.Obtener(FrontOfficeAppStart.UsuarioVisualizando());

                    var mail = new MailMessage();
                    mail.From = new MailAddress(model.Correo, model.Nombre);
                    mail.To.Add(_usuario.Email);
                    mail.Subject = "Correo desde contacto";
                    mail.IsBodyHtml = true;
                    mail.Body = model.Mensaje;

                    var SmtpServer = new SmtpClient("smtp.gmail.com"); // or "smtp.gmail.com"
                    SmtpServer.Port = 587;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;

                    // Agrega tu correo y tu contraseña, hemos usado el servidor de Outlook.
                    SmtpServer.Credentials = new System.Net.NetworkCredential("dcaballero@iconoi.com", "Iconoi.2012");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception e)
                {
                    rm.SetResponse(false, e.Message);
                    return Json(rm);
                    throw;
                }

                rm.SetResponse(true);
                rm.function = "CerrarContacto();";
            }
            return Json(rm);
        }

        public ActionResult ExportaAPDF() => new ActionAsPdf("PDF");

        public ActionResult PDF() => View(usuario.Obtener(FrontOfficeAppStart.UsuarioVisualizando(), true));
    }
}