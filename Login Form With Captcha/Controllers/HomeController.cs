using Login_Form_With_Captcha.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Login_Form_With_Captcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        Uri baseAdd = new Uri("http://localhost:63181/api");

        HttpClient client;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Login(string Email, String Password)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/LogIn/" + Email + Password).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult GetAuthCode()
        {
            string code = "";
            MemoryStream ms = new CaptchaHelper().Create(out code);
            string captcha = code;

            HttpContext.Session.SetString("cap", captcha);
            Response.Body.Dispose();
            return File(ms.ToArray(), @"image/png");
            //return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
    }
}
