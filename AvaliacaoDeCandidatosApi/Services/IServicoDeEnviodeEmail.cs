using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeEnvioDeEmail {
        Task EnvieEmailAsync(IConfiguracaoSmtp configuracaoSmtp, IEmail email);
    }
}