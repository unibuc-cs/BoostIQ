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
    [Route("api/UserLearnLevel")]
    [ApiController]
    public class UserLearnLevelController : ControllerBase
    {
        // GET: api/<UserLearnLevelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("scores")]
        public List<ScoreDTO> GetLearnScores()
        {
            List<ScoreDTO> scores = new List<ScoreDTO>();
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                var allUsers = repo.GetAll();
                foreach(var user in allUsers)
                {
                    ScoreDTO score = new ScoreDTO()
                    {
                        username = user.Username,
                        score = user.UserLearnLevels.Count() * 50 //number of user learn levels * 50 points
                    };
                    scores.Add(score);
                }
            }

            //sort desc by score
            scores = scores.OrderByDescending(p => p.score).ToList();

            //setting positions
            int position = 1;
            foreach(var score in scores)
            {
                score.position = position++;
            }
            return scores;
        }



        // GET api/<UserLearnLevelController>/5
        [HttpGet("user/{userId}/category/{categoryId}")]
        public LearnLevelDTO Get(int userId, int categoryId)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LearnQuestionEntity, LearnQuestionDTO>();
                cfg.CreateMap<LearnQuestionAnswerEntity, LearnQuestionAnswerDTO>();
                cfg.CreateMap<LearnLevelEntity, LearnLevelDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            using (var uow = new UnitOfWork())
            {
                var userLearnLevelRepository = uow.GetRepository<IUserLearnLevelRepository>();
                var learnLevelRepository = uow.GetRepository<ILearnLevelRepository>();

                var userLearnLevels = userLearnLevelRepository.Get(userId, categoryId);

                var learnLevelEntity = learnLevelRepository.Get(categoryId, userLearnLevels.Count() + 1);
                if (learnLevelEntity == null) return null; //finished all levels or category doesnt have levels

                var learnLevelDTO = iMapper.Map<LearnLevelEntity, LearnLevelDTO>(learnLevelEntity);
                return learnLevelDTO;
            }
        }

        // POST api/<UserLearnLevelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserLearnLevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserLearnLevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
