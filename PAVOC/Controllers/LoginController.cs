using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;
using PAVOC.DataModel.UnitOfWork;
using PAVOC.OAuth2;

namespace PAVOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            IActionResult response = Unauthorized();
            UserEntity user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = Utils.GenerateJWT(user, _config);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        private UserEntity AuthenticateUser(LoginRequest login)
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();

                return repo.GetUserByUsernameAndPassword(login.username, login.password);
            }
        }
    }
}
