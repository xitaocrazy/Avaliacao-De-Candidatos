using System.Threading.Tasks;
using MimeKit;

namespace AvaliacaoDeCandidatosApi.Wrappers{
    public interface ISmtpClient{
        Task ConnectAsync(string servidor, int porta, bool useSsl);
        Task AuthenticateAsync(string usuario, string senha);
        Task SendAsync (MimeMessage mail);
        Task DisconnectAsync (bool quit);
    }
}