using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ModelTests {
    public class ConfiguracaoSmtpTests{
        private ConfiguracaoSmtp _configuracao1;
        private ConfiguracaoSmtp _configuracao2;
        private ConfiguracaoSmtp _configuracao3;

        [Fact]
        public void ToString_de_retornar_o_valor_esperado() {
            CreateConfiguracoes();
            const string esperado = "Servidor: smtp.gmail.com - Porta: 587";

            var retornado = _configuracao1.ToString();

            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void Equals_method_deve_indicar_que_os_objetos_sao_iguais() {
            CreateConfiguracoes();

            Assert.True(_configuracao1.Equals(_configuracao2));
        }

        [Fact]
        public void Equals_method_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateConfiguracoes();

            Assert.False(_configuracao1.Equals(_configuracao3));
        }

        [Fact]
        public void Object_Equals_method_deve_indicar_que_os_objetos_sao_iguais() {
            CreateConfiguracoes();

            Assert.True(Equals(_configuracao1, _configuracao2));
        }

        [Fact]
        public void Object_Equals_method_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateConfiguracoes();

            Assert.False(Equals(_configuracao1, _configuracao3));
        }

        [Fact]
        public void Equals_operator_deve_indicar_que_os_objetos_sao_iguais() {
            CreateConfiguracoes();

            Assert.True(_configuracao1 == _configuracao2);
        }

        [Fact]
        public void Equals_operator_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateConfiguracoes();

            Assert.False(_configuracao1 == _configuracao3);
        }

        [Fact]
        public void NotEquals_operator_deve_indicar_que_os_objetos_nao_sao_diferentes() {
            CreateConfiguracoes();

            Assert.False(_configuracao1 != _configuracao2);
        }

        [Fact]
        public void NotEquals_operator_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateConfiguracoes();

            Assert.True(_configuracao1 != _configuracao3);
        }

        [Fact]
        public void GetHashCode_deve_retornar_o_valor_esperado() {
            CreateConfiguracoes();
            
            var esperado = GetHashCode(_configuracao1);

            var retornado = _configuracao1.GetHashCode();

            Assert.Equal(esperado, retornado);
        }

        private static int GetHashCode(ConfiguracaoSmtp configuracaoSmtp) {
            unchecked {
                var hashCode = configuracaoSmtp.Servidor?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ configuracaoSmtp.Porta.GetHashCode();
                hashCode = (hashCode * 397) ^ configuracaoSmtp.Usuario?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ configuracaoSmtp.Senha?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ configuracaoSmtp.UseSsl.GetHashCode();
                hashCode = (hashCode * 397) ^ configuracaoSmtp.RequerAutenticacao.GetHashCode();
                hashCode = (hashCode * 397) ^ configuracaoSmtp.Encoding?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        private void CreateConfiguracoes(){
            _configuracao1 = new ConfiguracaoSmtp{
                Servidor = "smtp.gmail.com",
                Porta = 587,
                Usuario = "teste@gmail.com",
                Senha = "teste",
                UseSsl = false,
                RequerAutenticacao = false,
                Encoding = string.Empty               
            };

            _configuracao2 = new ConfiguracaoSmtp{
                Servidor = "smtp.gmail.com",
                Porta = 587,
                Usuario = "teste@gmail.com",
                Senha = "teste",
                UseSsl = false,
                RequerAutenticacao = false,
                Encoding = string.Empty                 
            };

            _configuracao3 = new ConfiguracaoSmtp{
                Servidor = "smtp.gmail.com",
                Porta = 588,
                Usuario = "teste@gmail.com",
                Senha = "teste",
                UseSsl = false,
                RequerAutenticacao = false,
                Encoding = string.Empty                
            };
        }
    }
}