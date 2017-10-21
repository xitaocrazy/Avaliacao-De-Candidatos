using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeEnviodeEmails {
        Task EnvieEmailAsync(IOptions<ConfiguracaoSmtp> configuracaoSmtp, IEmail email);
    }
}