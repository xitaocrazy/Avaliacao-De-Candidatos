using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace AvaliacaoDeCandidatosApi.Wrappers{
    public class SmtpClientWrapper : ISmtpClient{
        public SmtpClient SmtpClient {get; set;}

        public SmtpClientWrapper(){
            SmtpClient = new SmtpClient();
        }

        public async Task ConnectAsync(string servidor, int porta, bool useSsl){
            await SmtpClient.ConnectAsync(servidor, porta, useSsl);
            SmtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
        }
        public async Task AuthenticateAsync(string usuario, string senha){
            await SmtpClient.AuthenticateAsync(usuario, senha);
        }
        public async Task SendAsync (MimeMessage mail){
            await SmtpClient.SendAsync(mail);
        }
        public async Task DisconnectAsync (bool quit){
            await SmtpClient.DisconnectAsync(quit);
        }
    }
}