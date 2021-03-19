using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_Application.Models;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace My_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your Contact page.";

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(name: "Arvinmoj", address: "arvinmojaverian@hotmail.com" ));

            message.To.Add(new MailboxAddress(name: "Arvin" , address: "Arvin.mojaverian@gmail.com"));

            message.Subject = "Arvinmoj";

            message.Body = new TextPart("Temp")
            {
                Text = "Send Email Address Successes" 
            };


            using(var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com" , 587 , false);
                client.Authenticate( userName: "arvinmojaverian@hotmail.com", password: "Arvinmoj!1q2w3e!");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
