using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppGrupo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class libraryController : ControllerBase
    {
        // GET: api/library
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/library/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/library
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/library/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/library/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
