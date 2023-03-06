using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Form_With_Captcha_API.Models;
using Login_Form_With_Captcha_API.Services;

namespace Login_Form_With_Captcha_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogInService _logInService;
        public LogInController(ILogInService logInService)
        {
            _logInService = logInService;
        }
        [HttpGet]
        public async Task<ActionResult<LogInEntity>> LogIn(string Email, String Password)
        {
            return await _logInService.LogIn(Email, Password);
        }
    }
}
