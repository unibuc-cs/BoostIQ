﻿using System;
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
    [Route("api/LearnLevel")]
    [ApiController]
    public class LearnLevelController : ControllerBase
    {
        // GET: api/LearnLevel
        [HttpGet]
        public IList<LearnLevelDTO> Get()
        {
            using (var uow = new UnitOfWork())
            {
                
                
                    var repo = uow.GetRepository<ILearnLevelRepository>();
                    var learnLevels = repo.GetAll();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<LearnQuestionEntity, LearnQuestionDTO>();
                    cfg.CreateMap<LearnQuestionAnswerEntity, LearnQuestionAnswerDTO>();
                    cfg.CreateMap <LearnLevelEntity,LearnLevelDTO>();
                });
                IMapper iMapper = config.CreateMapper();
                var learnLevelDTOs = iMapper.Map<List<LearnLevelEntity>, List<LearnLevelDTO>>(learnLevels.ToList());
                return learnLevelDTOs;
 
                
                
            }
        }

        // GET api/<LearnLevelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LearnLevelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LearnLevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LearnLevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
