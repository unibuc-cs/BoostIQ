using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAVOC.Common.DTO;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;
using PAVOC.DataModel.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAVOC.Controllers
{
    [Route("api/UserTestLevel")]
    [ApiController]
    public class UserTestLevelController : ControllerBase
    {
        // GET: api/<UserTestLevelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/<UserTestLevelController>/5
        [HttpGet("user/{userId}/category/{categoryId}")]
        public TestLevelDTO Get(int userId, int categoryId)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TestQuestionEntity, TestQuestionDTO>();
                cfg.CreateMap<TestQuestionAnswerEntity, TestQuestionAnswerDTO>();
                cfg.CreateMap<TestLevelEntity, TestLevelDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var uow = new UnitOfWork())
            {
                var userTestLevelRepository = uow.GetRepository<IUserTestLevelRepository>();
                var testLevelRepository = uow.GetRepository<ITestLevelRepository>();

                var userTestLevels = userTestLevelRepository.Get(userId, categoryId);

                var testLevelEntity = testLevelRepository.Get(categoryId, userTestLevels.Count() + 1);
                if (testLevelEntity == null) return null; //finished all levels or category doesnt have levels

                var testLevelDTO = iMapper.Map<TestLevelEntity, TestLevelDTO>(testLevelEntity);
                return testLevelDTO;
            }
        }

        // POST api/<UserTestLevelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserTestLevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTestLevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
