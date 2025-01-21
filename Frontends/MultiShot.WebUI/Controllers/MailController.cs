using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShot.WebUI.Models;

namespace MultiShot.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest )
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress mailbox = new MailboxAddress("multishopmail", "maralyunus42@gmail.com");
            message.From.Add(mailbox);
            MailboxAddress mailbox1 = new MailboxAddress("User", mailRequest.ReceiverMail);
            message.To.Add(mailbox1);
            var bodybuilder = new BodyBuilder();    
            bodybuilder.TextBody = mailRequest.Content;
            message.Body = bodybuilder.ToMessageBody();
            message.Subject= mailRequest.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("maralyunus42@gmail.com", "wmkxivnlplkdravh");
            smtpClient.Send(message);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
//cuno bund yqfn lvkn

