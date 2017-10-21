using AvaliacaoDeCandidatosApi.Models;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ModelTests {
    public class Candidatotests {
        private Candidato _candidato1;
        private Candidato _candidato2;
        private Candidato _candidato3;

        [Fact]
        public void ToStringTest_de_retornar_o_valor_esperado() {
            CreateCandidatos();
            const string esperado = "Nome: CandidatoTeste1 - Email: candidato@teste1.com";

            var retornado = _candidato1.ToString();

            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(_candidato1.Equals(_candidato2));
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_candidato1.Equals(_candidato3));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(Equals(_candidato1, _candidato2));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(Equals(_candidato1, _candidato3));
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(_candidato1 == _candidato2);
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_candidato1 == _candidato3);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_nao_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_candidato1 != _candidato2);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.True(_candidato1 != _candidato3);
        }

        [Fact]
        public void GetHashCodeTest_deve_retornar_o_valor_esperado() {
            CreateCandidatos();
            
            var esperado = GetHashCode(_candidato1);

            var retornado = _candidato1.GetHashCode();

            Assert.Equal(esperado, retornado);
        }

        private static int GetHashCode(Candidato candidato) {
            unchecked {
                var hashCode = candidato.Nome?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ candidato.Email?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ candidato.HTML.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.CSS.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.Javascript.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.Python.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.Django.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.Ios.GetHashCode();
                hashCode = (hashCode * 397) ^ candidato.Android.GetHashCode();
                return hashCode;
            }
        }

        private void CreateCandidatos(){
            _candidato1 = new Candidato{
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

            _candidato2 = new Candidato{
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

            _candidato3 = new Candidato{
                Nome = "CandidatoTeste1",
                Email = "candidato@teste1.com",
                HTML = 8,
                CSS = 6,
                Javascript = 9,
                Python = 5,
                Django = 6,
                Ios = 1,
                Android = 1                
            };
        }
    }
}