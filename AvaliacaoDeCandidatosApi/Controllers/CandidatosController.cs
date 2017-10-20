using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoDeCandidatosApi.Controllers {
    [Route("api/[controller]")]
    public class CandidatosController : Controller {
        // GET api/candidatos
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/candidatos/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/candidatos
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/candidatos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/candidatos/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}