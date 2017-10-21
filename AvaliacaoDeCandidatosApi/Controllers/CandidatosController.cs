using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace AvaliacaoDeCandidatosApi.Controllers {
    [Route("api/[controller]")]
    public class CandidatosController : Controller {
        private IConfiguracaoSmtp _configuracaoSmtp;

        public CandidatosController(IOptions<ConfiguracaoSmtp> configuracaoSmtp){
            _configuracaoSmtp = configuracaoSmtp.Value;
        }

        // GET api/candidatos
        [HttpGet]
        public IEnumerable<dynamic> Get() {
            return new [] { _configuracaoSmtp };
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