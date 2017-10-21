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

        private IServicoDeQualificacaoDeCandidatos _servicoDeQualificacaoDeCandidatos;

        public CandidatosController(IOptions<ConfiguracaoSmtp> configuracaoSmtp, IServicoDeEnvioDeEmail servicoDeEnvioDeEmail, 
                                    ISmtpClient smtpClient, IServicoDeQualificacaoDeCandidatos servicoDeQualificacaoDeCandidatos){
            _configuracaoSmtp = configuracaoSmtp.Value;
            _servicoDeEnvioDeEmail = servicoDeEnvioDeEmail;
            _smtpClient = smtpClient;
            _servicoDeQualificacaoDeCandidatos = servicoDeQualificacaoDeCandidatos;
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
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 8,
                CSS = 8,
                Javascript = 8,
                Python = 8,
                Django = 8,
                Ios = 2,
                Android = 8                
            };
            //_servicoDeEnvioDeEmail.EnvieEmailAsync(_configuracaoSmtp, email, _smtpClient);
            _servicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);
            var retorno = _servicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, "origem@gail.com");
            return retorno;
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