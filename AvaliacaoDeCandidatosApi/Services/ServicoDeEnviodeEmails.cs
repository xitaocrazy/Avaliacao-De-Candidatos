using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Exceptions;
using AvaliacaoDeCandidatosApi.Models;
using AvaliacaoDeCandidatosApi.Wrappers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AvaliacaoDeCandidatosApi.Services {
    public class ServicoDeEnvioDeEmail : IServicoDeEnvioDeEmail {
        private IConfiguracaoSmtp _configuracaoSmtp;
        private ISmtpClient _smtpClient;

        public async Task EnvieEmailAsync(IConfiguracaoSmtp configuracaoSmtp, IEmail email, ISmtpClient smtpClient){
            _configuracaoSmtp = configuracaoSmtp;
            _smtpClient = smtpClient;

            var mail = new MimeMessage();
            SetParametrosDoemail(ref mail, email);
            ConstruaCorpoDoEmail(ref mail, email);
            await EnvieEmailAsync(mail);
        }

        public async Task EnvieEmailsAsync(IConfiguracaoSmtp configuracaoSmtp, IList<IEmail> emails, ISmtpClient smtpClient){
            _configuracaoSmtp = configuracaoSmtp;
            _smtpClient = smtpClient;
            var mails = new List<MimeMessage>();
            foreach(var email in emails){
                var mail = new MimeMessage();
                SetParametrosDoemail(ref mail, email);
                ConstruaCorpoDoEmail(ref mail, email);
                mails.Add(mail);
            }
            await EnvieEmailsAsync(mails);
        }

        private void SetParametrosDoemail(ref MimeMessage mail, IEmail email){
            VerifiqueSeOsParametrosObrigatoriosForamInformados(email);
            
            mail.From.Add(new MailboxAddress(string.Empty, email.Origem));
            mail.To.Add(new MailboxAddress(string.Empty, email.Destino));
            if(!string.IsNullOrWhiteSpace(email.EncaminharPara)) {
                mail.ReplyTo.Add(new MailboxAddress(string.Empty, email.EncaminharPara));
            }
            mail.Subject = email.Assunto;
        }

        private void VerifiqueSeOsParametrosObrigatoriosForamInformados(IEmail email) {
            if (string.IsNullOrWhiteSpace(email.Destino)) {
                throw new ArgumentException("E-mail de destino não informado.");
            }

            if (string.IsNullOrWhiteSpace(email.Origem)) {
                throw new ArgumentException("E-mail de origem não informado.");
            }

            if (string.IsNullOrWhiteSpace(email.Assunto)) {
                throw new ArgumentException("Assunto não informado.");
            }
        }

        private void ConstruaCorpoDoEmail(ref MimeMessage mail, IEmail email){
            VerifiqueSeOConteudoFoiInformado(email);
            var bodyBuilder = new BodyBuilder();
            if(TemTexto(email)) {
                bodyBuilder.TextBody = email.MensagemDeTexto;
            }
            if (TemHtml(email)) {
                bodyBuilder.HtmlBody = email.MensagemHtml;
            }
            mail.Body = bodyBuilder.ToMessageBody();
        }

        private bool TemTexto(IEmail email){
            return !string.IsNullOrWhiteSpace(email.MensagemDeTexto);
        }

        private bool TemHtml(IEmail email){
            return !string.IsNullOrWhiteSpace(email.MensagemHtml);
        }

        private void VerifiqueSeOConteudoFoiInformado(IEmail email){
            if (!TemTexto(email) && !TemHtml(email)) {
                throw new ArgumentException("Nenhuma mensagem foi informada.");
            }
        }

        private async Task EnvieEmailAsync(MimeMessage mail){
            try{
                await _smtpClient.ConnectAsync(_configuracaoSmtp.Servidor, _configuracaoSmtp.Porta, _configuracaoSmtp.UseSsl).ConfigureAwait(false);
                if(_configuracaoSmtp.RequerAutenticacao) {
                    await _smtpClient.AuthenticateAsync(_configuracaoSmtp.Usuario, _configuracaoSmtp.Senha).ConfigureAwait(false);
                }               
                await _smtpClient.SendAsync(mail).ConfigureAwait(false);
                await _smtpClient.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex){
                throw new EnvioDeEmailException("Erro ao enviar o e-mail.", ex.InnerException);
            }
        }

        private async Task EnvieEmailsAsync(List<MimeMessage> mails){
            try{
                await _smtpClient.ConnectAsync(_configuracaoSmtp.Servidor, _configuracaoSmtp.Porta, _configuracaoSmtp.UseSsl).ConfigureAwait(false);
                if(_configuracaoSmtp.RequerAutenticacao) {
                    await _smtpClient.AuthenticateAsync(_configuracaoSmtp.Usuario, _configuracaoSmtp.Senha).ConfigureAwait(false);
                } 
                foreach(var mail in mails){              
                    await _smtpClient.SendAsync(mail).ConfigureAwait(false);
                }
                await _smtpClient.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex){
                throw new EnvioDeEmailException("Erro ao enviar os e-mails.", ex.InnerException);
            }
        }
    }
}