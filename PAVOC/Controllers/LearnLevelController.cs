using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<LearnLevelEntity> Get()
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<ILearnLevelRepository>();
                return repo.GetAll();
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
