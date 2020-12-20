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
    [Route("api/[controller]")]
    [ApiController]
    public class TestLevelController : ControllerBase
    {
         // GET: api/LearnLevel
        [HttpGet]
        public IEnumerable<TestLevelEntity> Get()
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<ITestLevelRepository>();
                return repo.GetAll();
            }
        }

        // GET api/<TestLevelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestLevelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestLevelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestLevelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
