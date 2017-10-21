using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ModelTests {
    public class EmailTests{
        private Email _email1;
        private Email _email2;
        private Email _email3;

        [Fact]
        public void ToStringTest_de_retornar_o_valor_esperado() {
            CreateEmails();
            const string esperado = "Origem: origem@gmail.com - Destino: destino@gmail.com - Assunto: Aquele assunto";

            var retornado = _email1.ToString();

            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateEmails();

            Assert.True(_email1.Equals(_email2));
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateEmails();

            Assert.False(_email1.Equals(_email3));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateEmails();

            Assert.True(Equals(_email1, _email2));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateEmails();

            Assert.False(Equals(_email1, _email3));
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateEmails();

            Assert.True(_email1 == _email2);
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateEmails();

            Assert.False(_email1 == _email3);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_nao_sao_diferentes() {
            CreateEmails();

            Assert.False(_email1 != _email2);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateEmails();

            Assert.True(_email1 != _email3);
        }

        [Fact]
        public void GetHashCodeTest_deve_retornar_o_valor_esperado() {
            CreateEmails();
            
            var esperado = GetHashCode(_email1);

            var retornado = _email1.GetHashCode();

            Assert.Equal(esperado, retornado);
        }

        private static int GetHashCode(Email email) {
            unchecked {
                var hashCode = email.Destino?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ email.Origem?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ email.Assunto?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ email.MensagemDeTexto?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ email.MensagemHtml?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ email.EncaminharPara?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        private void CreateEmails(){
            _email1 = new Email{
                Destino = "destino@gmail.com",
                Origem = "origem@gmail.com",
                Assunto = "Aquele assunto",
                MensagemDeTexto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };

            _email2 = new Email{
                Destino = "destino@gmail.com",
                Origem = "origem@gmail.com",
                Assunto = "Aquele assunto",
                MensagemDeTexto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };

            _email3 = new Email{
                Destino = "destino@gmail.com",
                Origem = "origem@gmail.com",
                Assunto = "Aquele outro assunto",
                MensagemDeTexto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
        }
    }
}