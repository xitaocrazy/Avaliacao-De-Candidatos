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

        [HttpGet]
        public IEnumerable<Candidato> Get() {
            var candidatos = CrieListaDeCandidatos();
            return candidatos;
        }

        [HttpGet("{email}")]
        public Candidato Get(string email) {
            var candidatos = CrieListaDeCandidatos();
            return candidatos.FirstOrDefault(c => c.Email == email);
        }

        [HttpPost]
        public string Post([FromBody]Candidato candidato) {
            return "Seu cadastro foi realizado com sucesso. Iremos avaliar as informações e lhe retornaremos por e-mail.";
        }

        [HttpPut("{email}")]
        public string Put(string email, [FromBody]Candidato candidato) {
            return "Seu cadastro foi atualizado com sucesso. Iremos avaliar as informações e lhe retornaremos por e-mail.";
        }

        [HttpDelete("{email}")]
        public string Delete(string email) {
            return "Seu cadastro foi deletado com sucesso.";
        }


        private List<Candidato> CrieListaDeCandidatos(){
            var candidato1 = new Candidato{
                Nome = "CandidatoFrontEnd",
                Email = "candidato@frontend.com",
                HTML = 9,
                CSS = 8,
                Javascript = 9,
                Python = 5,
                Django = 5,
                Ios = 2,
                Android = 2               
            };
            var candidato2 = new Candidato{
                Nome = "CandidatoBackEnd",
                Email = "candidato@backend.com",
                HTML = 5,
                CSS = 3,
                Javascript = 7,
                Python = 8,
                Django = 8,
                Ios = 0,
                Android = 0                
            };
            var candidato3 = new Candidato{
                Nome = "CandidatoMobile",
                Email = "candidato@mobile.com",
                HTML = 3,
                CSS = 8,
                Javascript = 8,
                Python = 8,
                Django = 4,
                Ios = 8,
                Android = 8                
            };
            var candidato4 = new Candidato{
                Nome = "CandidatoFullStack",
                Email = "candidato@fullstack.com",
                HTML = 9,
                CSS = 9,
                Javascript = 9,
                Python = 9,
                Django = 9,
                Ios = 7,
                Android = 0                
            };
            var candidato5 = new Candidato{
                Nome = "Candidato",
                Email = "candidato@nenhum.com",
                HTML = 5,
                CSS = 3,
                Javascript = 7,
                Python = 5,
                Django = 5,
                Ios = 0,
                Android = 0                
            };
            var candidatos = new List<Candidato>{
                candidato1,
                candidato2,
                candidato3,
                candidato4,
                candidato5
            };
            foreach(var candidato in candidatos){
                _servicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);
            }
            return candidatos;
        }
    }
}