using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeEnviodeEmails {
        Task EnvieEmailAsync(
            IConfiguracaoSmtp configuracoesSmtp,
            string para,
            string deve,
            string titulo,
            string mensagemDeTexto,
            string mensagemHtml,
            string encaminharPara = null);
    }
}