using Login_Form_With_Captcha_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Form_With_Captcha_API.Services
{
    public interface ILogInService
    {
        public Task<LogInEntity> LogIn(string Email, String Password);
    }
}
