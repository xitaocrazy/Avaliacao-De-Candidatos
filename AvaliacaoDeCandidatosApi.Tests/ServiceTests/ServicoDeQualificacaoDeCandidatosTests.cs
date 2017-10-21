using System;
using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Enuns;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ServiceTests {
    public class ServicoDeQualificacaoDeCandidatosTests {  
        private const string Origem = "teste@gmail.com";

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_frontEnd() {
            var candidato = CrieCandidatoForntEnd();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.frontEnd, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_backEnd() {
            var candidato = CrieCandidatoBackEnd();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.backEnd, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_por_ios() {
            var candidato = CrieCandidatoMobileIos();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_por_android() {
            var candidato = CrieCandidatoMobileAndroid();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_ios_android() {
            var candidato = CrieCandidatoMobileIosAndroid();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_todos_stacks() {
            var candidato = CrieCandidatoFullStack();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(3, quantidade);
            Assert.Contains(Qualificacao.frontEnd, candidato.Qualificacoes);
            Assert.Contains(Qualificacao.backEnd, candidato.Qualificacoes);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_nenhuma_qualificacao() {
            var candidato = CrieCandidato();
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.nenhum, candidato.Qualificacoes);
        }

        [Fact]
        public void GetEmailDeRetornoTest_deve_retornar_email_para_frontEnd() {
            var candidato = CrieCandidatoForntEnd();
            candidato.Qualificacoes = new List<Qualificacao>{
                Qualificacao.frontEnd
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            var emails = ServicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, Origem);
            
            var quantidade = emails.Count;            
            Assert.Equal(1, quantidade);
            var emailEsperado = GetEmailFrontEnd(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
        }

        [Fact]
        public void GetEmailDeRetornoTest_deve_retornar_email_para_backEnd() {
            var candidato = CrieCandidatoBackEnd();
            candidato.Qualificacoes = new List<Qualificacao>{
                Qualificacao.backEnd
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            var emails = ServicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, Origem);

            var quantidade = emails.Count;            
            Assert.Equal(1, quantidade);
            var emailEsperado = GetEmailBackEnd(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
        }

        [Fact]
        public void GetEmailDeRetornoTest_deve_retornar_email_para_mobile() {
            var candidato = CrieCandidatoMobileIosAndroid();
            candidato.Qualificacoes = new List<Qualificacao>{
                Qualificacao.mobile
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            var emails = ServicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, Origem);

            var quantidade = emails.Count;            
            Assert.Equal(1, quantidade);
            var emailEsperado = GetEmailMobile(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
        }

        [Fact]
        public void GetEmailDeRetornoTest_deve_retornar_email_para_todos_stacks() {
            var candidato = CrieCandidatoFullStack();            
            candidato.Qualificacoes = new List<Qualificacao>{
                Qualificacao.backEnd,
                Qualificacao.frontEnd,
                Qualificacao.mobile
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            var emails = ServicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, Origem);
            
            var quantidade = emails.Count;
            Assert.Equal(3, quantidade);
            var emailEsperado = GetEmailFrontEnd(candidato.Email, Origem);            
            Assert.Contains(emailEsperado, emails);
            emailEsperado = GetEmailBackEnd(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
            emailEsperado = GetEmailMobile(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
        }

        [Fact]
        public void GetEmailDeRetornoTest_deve_retornar_email_generico() {
            var candidato = CrieCandidato();
            candidato.Qualificacoes = new List<Qualificacao>{
                Qualificacao.nenhum
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            var emails = ServicoDeQualificacaoDeCandidatos.GetEmailDeRetorno(candidato, Origem);

            var quantidade = emails.Count;            
            Assert.Equal(1, quantidade);
            var emailEsperado = GetEmailGenerico(candidato.Email, Origem);
            Assert.Contains(emailEsperado, emails);
        }


        private Candidato CrieCandidatoForntEnd(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 8,
                CSS = 7,
                Javascript = 9,
                Python = 5,
                Django = 3,
                Ios = 1,
                Android = 1                
            };
            return candidato;
        }

        private Candidato CrieCandidatoBackEnd(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 4,
                CSS = 4,
                Javascript = 4,
                Python = 8,
                Django = 8,
                Ios = 1,
                Android = 1                
            };
            return candidato;
        }

        private Candidato CrieCandidatoMobileIos(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 4,
                CSS = 4,
                Javascript = 4,
                Python = 3,
                Django = 3,
                Ios = 8,
                Android = 1                
            };
            return candidato;
        }

        private Candidato CrieCandidatoMobileAndroid(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 4,
                CSS = 4,
                Javascript = 4,
                Python = 3,
                Django = 3,
                Ios = 1,
                Android = 8                
            };
            return candidato;
        }

        private Candidato CrieCandidatoMobileIosAndroid(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 4,
                CSS = 4,
                Javascript = 4,
                Python = 3,
                Django = 3,
                Ios = 8,
                Android = 8                
            };
            return candidato;
        }

        private Candidato CrieCandidatoFullStack(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 8,
                CSS = 7,
                Javascript = 8,
                Python = 8,
                Django = 7,
                Ios = 7,
                Android = 7                
            };
            return candidato;
        }

        private Candidato CrieCandidato(){
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 6,
                CSS = 6,
                Javascript = 6,
                Python = 6,
                Django = 6,
                Ios = 6,
                Android = 6                
            };
            return candidato;
        }

        private Email GetEmailFrontEnd(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Front-End entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailBackEnd(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Back-End entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailMobile(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Mobile entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailGenerico(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }
    }
}