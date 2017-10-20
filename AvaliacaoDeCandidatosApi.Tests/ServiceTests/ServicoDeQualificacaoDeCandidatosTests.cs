using System;
using AvaliacaoDeCandidatosApi.Enuns;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Services;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ServiceTests {
    public class ServicoDeQualificacaoDeCandidatosTests {        
        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_frontEnd() {
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
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.frontEnd, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_backEnd() {
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
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.backEnd, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_1() {
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 3,
                CSS = 3,
                Javascript = 3,
                Python = 5,
                Django = 3,
                Ios = 8,
                Android = 1                
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_2() {
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 3,
                CSS = 3,
                Javascript = 3,
                Python = 5,
                Django = 3,
                Ios = 1,
                Android = 8                
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_mobile_3() {
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 3,
                CSS = 3,
                Javascript = 3,
                Python = 5,
                Django = 3,
                Ios = 7,
                Android = 7               
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.mobile, candidato.Qualificacoes);
        }

        [Fact]
        public void QualifiqueCandidatoTest_deve_indicar_qualificacao_para_todos_stacks() {
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 8,
                CSS = 7,
                Javascript = 9,
                Python = 7,
                Django = 7,
                Ios = 7,
                Android = 7                
            };
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
            var candidato = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 5,
                CSS = 5,
                Javascript = 5,
                Python = 5,
                Django = 3,
                Ios = 1,
                Android = 1                
            };
            var ServicoDeQualificacaoDeCandidatos = new ServicoDeQualificacaoDeCandidatos();

            ServicoDeQualificacaoDeCandidatos.QualifiqueCandidato(candidato);

            var quantidade = candidato.Qualificacoes.Count;
            Assert.Equal(1, quantidade);
            Assert.Contains(Qualificacao.nenhum, candidato.Qualificacoes);
        }
    }
}