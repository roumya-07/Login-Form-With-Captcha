using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Form_With_Captcha.Models
{
    public class LogInEntity
    {
        public int Sl_No { get; set; } = 0;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
