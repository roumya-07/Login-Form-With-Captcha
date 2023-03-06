using Dapper;
using Login_Form_With_Captcha_API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Form_With_Captcha_API.Repository
{
    public class LogInRepository : BaseRepository, ILogInRepository
    {
        public LogInRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<LogInEntity> LogIn(string Email, String Password)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Email", Email);
                param.Add("@Password", Password);
                param.Add("@Action", "LogIn");
                var lstste = await cn.QueryAsync<LogInEntity>("Login_Form_With_Captcha", param, commandType: CommandType.StoredProcedure);
                return lstste.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
