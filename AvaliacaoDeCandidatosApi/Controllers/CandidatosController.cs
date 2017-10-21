using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using AvaliacaoDeCandidatosApi.Wrappers;

namespace AvaliacaoDeCandidatosApi.Controllers {
    [Route("api/[controller]")]
    public class CandidatosController : Controller {
        private IConfiguracaoSmtp _configuracaoSmtp;
        private IServicoDeEnvioDeEmail _servicoDeEnvioDeEmail;
        private ISmtpClient _smtpClient;

        public CandidatosController(IOptions<ConfiguracaoSmtp> configuracaoSmtp, IServicoDeEnvioDeEmail servicoDeEnvioDeEmail, ISmtpClient smtpClient){
            _configuracaoSmtp = configuracaoSmtp.Value;
            _servicoDeEnvioDeEmail = servicoDeEnvioDeEmail;
            _smtpClient = smtpClient;
        }

        // GET api/candidatos
        [HttpGet]
        public IEnumerable<dynamic> Get() {
            var email = new Email{
                Destino = "xitaocrazy@gmail.com",
                Origem = "danieldesouzamartins@gmail.com",
                Assunto = "teste de envio",
                MensagemDeTexto = "Isto é um teste",
                MensagemHtml = string.Empty,
                EncaminharPara = string.Empty
            };
            _servicoDeEnvioDeEmail.EnvieEmailAsync(_configuracaoSmtp, email, _smtpClient);
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