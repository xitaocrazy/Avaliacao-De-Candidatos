using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Wrappers;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeEnvioDeEmail {
        Task EnvieEmailAsync(IConfiguracaoSmtp configuracaoSmtp, IEmail email, ISmtpClient smtpClient);
    }
}