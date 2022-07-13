using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendEmailProject.Models;
using SendEmailProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISendEmailService _sendEmailService;

        public HomeController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TestSendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestSendEmail(MailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var myList = new List<string>() { model.To };
                MailOptionsModel mailOptionsModel = new MailOptionsModel()
                {
                    To = myList,
                    Subject = model.Subject,
                    Body = model.Body
                };

                await _sendEmailService.sendEmail(mailOptionsModel);
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
