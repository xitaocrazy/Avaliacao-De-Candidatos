using System;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using Xunit;
using Moq;
using AvaliacaoDeCandidatosApi.Wrappers;
using MimeKit;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Exceptions;
using System.Collections.Generic;

namespace AvaliacaoDeCandidatosApi.Tests.ServiceTests {
    public class ServicoDeEnvioDeEmailTests{
        private Mock<ISmtpClient> _smtpMock;

         [Fact]
         public async void EnvieEmailAsyncTest_deve_chamar_ConnectAsync(){
             ConfigureSmtpMock();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object);

             _smtpMock.Verify(s => s.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);
         }

         [Fact]
         public async void EnvieEmailAsyncTest_nao_deve_chamar_AuthenticateAsync_quando_nao_requer_autenticacao(){
             ConfigureSmtpMock();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object);

             _smtpMock.Verify(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
         }

         [Fact]
         public async void EnvieEmailAsyncTest_deve_chamar_AuthenticateAsync_quando_requer_autenticacao(){
             ConfigureSmtpMock();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();
             configuracaoSmtp.RequerAutenticacao = true;
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object);

             _smtpMock.Verify(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
         }

         [Fact]
         public async void EnvieEmailAsyncTest_deve_chamar_SendAsync(){
             ConfigureSmtpMock();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object);

             _smtpMock.Verify(s => s.SendAsync(It.IsAny<MimeMessage>()), Times.Once);
         }

         [Fact]
         public async void EnvieEmailAsyncTest_deve_chamar_DisconnectAsync(){
             ConfigureSmtpMock();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object);

             _smtpMock.Verify(s => s.DisconnectAsync(It.IsAny<bool>()), Times.Once);
         }

         [Fact]
         public void EnvieEmailAsyncTest_deve_retornar_excecao_quando_email_de_origem_nao_informado(){
             ConfigureSmtpMock();
             var email = GetEmail();
             email.Origem = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object));

             Assert.Equal("E-mail de origem não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailAsyncTest_deve_retornar_excecao_quando_email_de_destino_nao_informado(){
             ConfigureSmtpMock();
             var email = GetEmail();
             email.Destino = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object));

             Assert.Equal("E-mail de destino não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailAsyncTest_deve_retornar_excecao_quando_assunto_nao_informado(){
             ConfigureSmtpMock();
             var email = GetEmail();
             email.Assunto = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object));

             Assert.Equal("Assunto não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailAsyncTest_deve_retornar_excecao_quando_nenhum_conteudo_for_informado(){
             ConfigureSmtpMock();
             var email = GetEmail();
             email.MensagemDeTexto = string.Empty;
             email.MensagemHtml = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object));

             Assert.Equal("Nenhuma mensagem foi informada.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailAsyncTest_deve_retornar_excecao_quando_ocorrer_algum_erro_no_envio_do_email(){
             ConfigureSmtpMockComErro();
             var email = GetEmail();
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<EnvioDeEmailException>(() => servicoDeEnvioDeEmail.EnvieEmailAsync(configuracaoSmtp, email, _smtpMock.Object));

             Assert.Equal("Erro ao enviar o e-mail.", ex.Result.Message);
         }

         [Fact]
         public async void EnvieEmailsAsyncTest_deve_chamar_ConnectAsync(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object);

             _smtpMock.Verify(s => s.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);
         }

         [Fact]
         public async void EnvieEmailsAsyncTest_nao_deve_chamar_AuthenticateAsync_quando_nao_requer_autenticacao(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object);

             _smtpMock.Verify(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
         }

         [Fact]
         public async void EnvieEmailsAsyncTest_deve_chamar_AuthenticateAsync_quando_requer_autenticacao(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();
             configuracaoSmtp.RequerAutenticacao = true;
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object);

             _smtpMock.Verify(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
         }

         [Fact]
         public async void EnvieEmailsAsyncTest_deve_chamar_SendAsync(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object);

             _smtpMock.Verify(s => s.SendAsync(It.IsAny<MimeMessage>()), Times.Exactly(3));
         }

         [Fact]
         public async void EnvieEmailsAsyncTest_deve_chamar_DisconnectAsync(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();
             
             await servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object);

             _smtpMock.Verify(s => s.DisconnectAsync(It.IsAny<bool>()), Times.Once);
         }

         [Fact]
         public void EnvieEmailsAsyncTest_deve_retornar_excecao_quando_email_de_origem_nao_informado(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             emails[1].Origem = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object));

             Assert.Equal("E-mail de origem não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailsAsyncTest_deve_retornar_excecao_quando_email_de_destino_nao_informado(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             emails[1].Destino = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object));

             Assert.Equal("E-mail de destino não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailsAsyncTest_deve_retornar_excecao_quando_assunto_nao_informado(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             emails[0].Assunto = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object));

             Assert.Equal("Assunto não informado.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailsAsyncTest_deve_retornar_excecao_quando_nenhum_conteudo_for_informado(){
             ConfigureSmtpMock();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             emails[0].MensagemDeTexto = string.Empty;
             emails[0].MensagemHtml = string.Empty;
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<ArgumentException>(() => servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object));

             Assert.Equal("Nenhuma mensagem foi informada.", ex.Result.Message);
         }

         [Fact]
         public void EnvieEmailsAsyncTest_deve_retornar_excecao_quando_ocorrer_algum_erro_no_envio_do_email(){
             ConfigureSmtpMockComErro();
             var emails = new List<IEmail>{
                 GetEmail(),
                 GetEmail(),
                 GetEmail()
             };
             var configuracaoSmtp = GetConfiguracaoSmtp();             
             var servicoDeEnvioDeEmail = new ServicoDeEnvioDeEmail();

             var ex = Assert.ThrowsAsync<EnvioDeEmailException>(() => servicoDeEnvioDeEmail.EnvieEmailsAsync(configuracaoSmtp, emails, _smtpMock.Object));

             Assert.Equal("Erro ao enviar os e-mails.", ex.Result.Message);
         }

         private void ConfigureSmtpMock(){
             _smtpMock = new Mock<ISmtpClient>(MockBehavior.Strict);
             _smtpMock.Setup(s => s.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.FromResult(true));
             _smtpMock.Setup(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));
             _smtpMock.Setup(s => s.SendAsync(It.IsAny<MimeMessage>())).Returns(Task.FromResult(true));
             _smtpMock.Setup(s => s.DisconnectAsync(It.IsAny<bool>())).Returns(Task.FromResult(true));
         }

         private IEmail GetEmail(){
             var email = new Email{
                Destino = "teste@gmail.com",
                Origem = "teste@gmail.com",
                Assunto = "teste de envio",
                MensagemDeTexto = "Isto é um teste",
                MensagemHtml = string.Empty,
                EncaminharPara = string.Empty
            };
            return email;
         }

         private IConfiguracaoSmtp GetConfiguracaoSmtp(){
             var configuracaoSmtp = new ConfiguracaoSmtp{
                Servidor = "smtp.gmail.com",
                Porta = 587,
                Usuario = "teste@gmail.com",
                Senha = "teste",
                UseSsl = false,
                RequerAutenticacao = false,
                Encoding = string.Empty               
            };
            return configuracaoSmtp;
         }

         private void ConfigureSmtpMockComErro(){
             _smtpMock = new Mock<ISmtpClient>(MockBehavior.Strict);
             _smtpMock.Setup(s => s.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>())).ThrowsAsync(new Exception());
             _smtpMock.Setup(s => s.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception());
             _smtpMock.Setup(s => s.SendAsync(It.IsAny<MimeMessage>())).ThrowsAsync(new Exception());
             _smtpMock.Setup(s => s.DisconnectAsync(It.IsAny<bool>())).ThrowsAsync(new Exception());
         }
    }
}