using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Controllers;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using AvaliacaoDeCandidatosApi.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ModelTests {    
    public class CandidatosControllerTests{
        private Mock<IOptions<ConfiguracaoSmtp>> _optionsMock;
        private Mock<IServicoDeEnvioDeEmail> _servicoDeEnvioDeEmailMock;
        private Mock<ISmtpClient> _smtpClientMock;
        private Mock<IServicoDeQualificacaoDeCandidatos> _servicoDeQualificacaoDeCandidatosMock;
        private IConfigurationRoot _configuration;

        [Fact]
        public void CandidatosController_deve_buscar_as_configuracoes_no_construtor(){
            var candidatoController = CrieControllerParaTesteDePostComSucesso();
            
            var candidato = new Candidato();

            _optionsMock.Verify(o => o.Value, Times.Once);
        }

        [Fact]
        public void Post_deve_retornar_mensagem_esperada_quando_der_sucesso(){
            var candidatoController = CrieControllerParaTesteDePostComSucesso();
            var candidato = new Candidato();

            var retornado = candidatoController.Post(candidato);

            var esperado = "Seu cadastro foi realizado com sucesso. Iremos avaliar as informações e lhe retornaremos por e-mail.";
            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void Post_deve_chamar_QualifiqueCandidato(){
            var candidatoController = CrieControllerParaTesteDePostComSucesso();
            var candidato = new Candidato();

            var retornado = candidatoController.Post(candidato);

            _servicoDeQualificacaoDeCandidatosMock.Verify(s => s.QualifiqueCandidato(It.IsAny<ICandidato>()), Times.Once);
        }

        [Fact]
        public void Post_deve_chamar_GetEmailDeRetorno(){
            var candidatoController = CrieControllerParaTesteDePostComSucesso();
            var candidato = new Candidato();

            var retornado = candidatoController.Post(candidato);

            _servicoDeQualificacaoDeCandidatosMock.Verify(s => s.GetEmailDeRetorno(It.IsAny<ICandidato>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Post_deve_chamar_EnvieEmailsAsync(){
            var candidatoController = CrieControllerParaTesteDePostComSucesso();
            var candidato = new Candidato();

            var retornado = candidatoController.Post(candidato);

            _servicoDeEnvioDeEmailMock.Verify(s => s.EnvieEmailsAsync(It.IsAny<IConfiguracaoSmtp>(), It.IsAny<IList<IEmail>>(), It.IsAny<ISmtpClient>()), Times.Once);
        }

        [Fact]
        public void Post_deve_retornar_execao_quando_der_erro(){
            var candidatoController = CrieControllerParaTesteDePostComErro();
            var candidato = new Candidato();

            var ex = Assert.Throws<Exception>(() => candidatoController.Post(candidato));
            
            var esperado = "Erro ao processar os dados do candidato.";
            Assert.Equal(esperado, ex.Message);
        }

        private void CrieConfiguracoesBasicasParaOsTestes(){
            var configuracaoSmtp = new ConfiguracaoSmtp(); 
            _optionsMock = new Mock<IOptions<ConfiguracaoSmtp>>(MockBehavior.Strict);            
            _servicoDeEnvioDeEmailMock = new Mock<IServicoDeEnvioDeEmail>(MockBehavior.Strict);
            _smtpClientMock = new Mock<ISmtpClient>(MockBehavior.Strict);
            _servicoDeQualificacaoDeCandidatosMock = new Mock<IServicoDeQualificacaoDeCandidatos>(MockBehavior.Strict);            
            var configuracoes = new Dictionary<string, string> {
                {"EmailOrigem", "teste@gmail.com"}
            };
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(configuracoes);
            _configuration = builder.Build();
            _optionsMock.Setup(o => o.Value).Returns(configuracaoSmtp);
        }

        private CandidatosController CrieControllerParaTesteDePostComSucesso(){
            CrieConfiguracoesBasicasParaOsTestes();            
            _servicoDeQualificacaoDeCandidatosMock.Setup(s => s.QualifiqueCandidato(It.IsAny<ICandidato>()));
            _servicoDeQualificacaoDeCandidatosMock.Setup(s => s.GetEmailDeRetorno(It.IsAny<ICandidato>(), It.IsAny<string>())).Returns(new List<IEmail>());
            _servicoDeEnvioDeEmailMock.Setup(s => s.EnvieEmailsAsync(It.IsAny<IConfiguracaoSmtp>(), It.IsAny<IList<IEmail>>(), It.IsAny<ISmtpClient>())).Returns(Task.FromResult(true));

            var controller = new CandidatosController(_optionsMock.Object, _servicoDeEnvioDeEmailMock.Object, _smtpClientMock.Object, 
                                                      _servicoDeQualificacaoDeCandidatosMock.Object, _configuration);
            return controller;
        }

        private CandidatosController CrieControllerParaTesteDePostComErro(){
            CrieConfiguracoesBasicasParaOsTestes();            
            _servicoDeQualificacaoDeCandidatosMock.Setup(s => s.QualifiqueCandidato(It.IsAny<ICandidato>())).Throws(new Exception());
            var controller = new CandidatosController(_optionsMock.Object, _servicoDeEnvioDeEmailMock.Object, _smtpClientMock.Object, 
                                                      _servicoDeQualificacaoDeCandidatosMock.Object, _configuration);
            return controller;
        }
    }
}