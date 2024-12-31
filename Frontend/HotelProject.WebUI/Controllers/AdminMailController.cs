using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //kimden
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "semaaasahinn19@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //kime
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //içerik
            var bodyBuilder =new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            //başlık
            mimeMessage.Subject = model.Subject;
            //mail kit paketi kullanılacak sistem mail DEĞİL!!!
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            //uygulama şirelerinden aldığımız şifre
            client.Authenticate("semaaasahinn19@gmail.com", "qrlybssnkgfmuhng");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
