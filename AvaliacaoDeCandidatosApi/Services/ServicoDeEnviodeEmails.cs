using System;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AvaliacaoDeCandidatosApi.Services {
    public class ServicoDeEnvioDeEmail : IServicoDeEnvioDeEmail {
        private IConfiguracaoSmtp _configuracaoSmtp;
        private IEmail _email;
        private MimeMessage _mail; 

        public async Task EnvieEmailAsync(IConfiguracaoSmtp configuracaoSmtp, IEmail email){
            _configuracaoSmtp = configuracaoSmtp;
            _email = email;

            SetParametrosDoemail();
            ConstruaCorpoDoEmail();
            await EnvieEmailAsync();
        }

        private void SetParametrosDoemail(){
            VerifiqueSeOsParametrosObrigatoriosForamInformados();
            
            _mail = new MimeMessage();          
            _mail.From.Add(new MailboxAddress(string.Empty, _email.Origem));
            _mail.To.Add(new MailboxAddress(string.Empty, _email.Destino));
            if(!string.IsNullOrWhiteSpace(_email.EncaminharPara)) {
                _mail.ReplyTo.Add(new MailboxAddress(string.Empty, _email.EncaminharPara));
            }
            _mail.Subject = _email.Assunto;
        }

        private void VerifiqueSeOsParametrosObrigatoriosForamInformados() {
            if (string.IsNullOrWhiteSpace(_email.Origem)) {
                throw new ArgumentException("E-mail de destino não informado.");
            }

            if (string.IsNullOrWhiteSpace(_email.Origem)) {
                throw new ArgumentException("E-mail de origem não informado.");
            }

            if (string.IsNullOrWhiteSpace(_email.Assunto)) {
                throw new ArgumentException("Assunto não informado.");
            }
        }

        private void ConstruaCorpoDoEmail(){
            VerifiqueSeOConteudoFoiInformado();
            var bodyBuilder = new BodyBuilder();
            if(TemTexto()) {
                bodyBuilder.TextBody = _email.MensagemDeTexto;
            }
            if (TemHtml()) {
                bodyBuilder.HtmlBody = _email.MensagemHtml;
            }
            _mail.Body = bodyBuilder.ToMessageBody();
        }

        private bool TemTexto(){
            return !string.IsNullOrWhiteSpace(_email.MensagemDeTexto);
        }

        private bool TemHtml(){
            return !string.IsNullOrWhiteSpace(_email.MensagemHtml);
        }

        private void VerifiqueSeOConteudoFoiInformado(){
            if (!TemTexto() && !TemHtml()) {
                throw new ArgumentException("Nenhuma mensagem foi informada.");
            }
        }

        private async Task EnvieEmailAsync(){
            using (var client = new SmtpClient()) {
                await client.ConnectAsync(_configuracaoSmtp.Servidor, _configuracaoSmtp.Porta, _configuracaoSmtp.UseSsl).ConfigureAwait(false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                if(_configuracaoSmtp.RequerAutenticacao) {
                    await client.AuthenticateAsync(_configuracaoSmtp.Usuario, _configuracaoSmtp.Senha).ConfigureAwait(false);
                }               
                await client.SendAsync(_mail).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}