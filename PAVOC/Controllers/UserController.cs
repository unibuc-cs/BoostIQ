using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAVOC.Common.DTO;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;
using PAVOC.DataModel.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAVOC.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("passLearn/user/{userId}/learnLevel/{learnLevelId}")]
        public void PassLearnLevel(int userId, int learnLevelId)
        {
            using(var uow = new UnitOfWork())
            {
                var userRepo = uow.GetRepository<IUserRepository>();
                var user = userRepo.GetById(userId);
                UserLearnLevelEntity userLearnLevelEntity = new UserLearnLevelEntity()
                {
                    UserEntityId = userId,
                    LearnLevelEntityId = learnLevelId
                };
                user.UserLearnLevels.Add(userLearnLevelEntity);
                uow.Save();
            }

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("register")]
        public void Post([FromBody] UserRegisterDTO user)
        {
            using (var uow = new UnitOfWork())
            {
                var userRepo = uow.GetRepository<IUserRepository>();
                var userEntity = new UserEntity()
                {
                    Email = user.email,
                    Password = user.password,
                    Username = user.username
                };
                userRepo.Add(userEntity);
                uow.Save();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
