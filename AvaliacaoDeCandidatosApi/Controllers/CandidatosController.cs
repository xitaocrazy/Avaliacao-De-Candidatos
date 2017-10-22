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
        private string _emailOrigem;

        public CandidatosController(IOptions<ConfiguracaoSmtp> configuracaoSmtp, 
                                    IServicoDeEnvioDeEmail servicoDeEnvioDeEmail, 
                                    ISmtpClient smtpClient, 
                                    IServicoDeQualificacaoDeCandidatos servicoDeQualificacaoDeCandidatos, 
                                    IConfiguration configuracao){
            _configuracaoSmtp = configuracaoSmtp.Value;
            _servicoDeEnvioDeEmail = servicoDeEnvioDeEmail;
            _smtpClient = smtpClient;
            _servicoDeQualificacaoDeCandidatos = servicoDeQualificacaoDeCandidatos;
            _emailOrigem = configuracao["EmailOrigem"];
        }

        [HttpPost]
        public string Post([FromBody]Candidato candidato) {
            try{
                _servicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);
                var emailsDeRetorno = _servicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, _emailOrigem);
                _servicoDeEnvioDeEmail.EnvieEmailsAsync(_configuracaoSmtp, emailsDeRetorno, _smtpClient);
                return "Seu cadastro foi realizado com sucesso. Iremos avaliar as informações e lhe retornaremos por e-mail.";
            }
            catch(Exception ex){
                throw new Exception("Erro ao processar os dados do candidato.", ex.InnerException);
            }
        }
    }
}