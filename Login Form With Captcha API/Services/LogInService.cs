using Login_Form_With_Captcha_API.Models;
using Login_Form_With_Captcha_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Form_With_Captcha_API.Services
{
    public class LogInService : ILogInService
    {
        private readonly ILogInRepository _logInRepository;
            public LogInService(ILogInRepository logInRepository)
        {
            _logInRepository = logInRepository;
        }

        public async Task<LogInEntity> LogIn(string Email, String Password)
        {
            return await _logInRepository.LogIn(Email, Password);
        }

    }
}
