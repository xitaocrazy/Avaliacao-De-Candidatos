using System;
using System.Threading.Tasks;
using AvaliacaoDeCandidatosApi.Models;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Services {
    public class ServicoDeEnviodeEmails : IServicoDeEnviodeEmails {
        private IConfiguracaoSmtp _configuracaoSmtp;
        private IEmail _email;

        public async Task EnvieEmailAsync(IOptions<ConfiguracaoSmtp> configuracaoSmtp, IEmail email){
            _configuracaoSmtp = configuracaoSmtp.Value;
            _email = email;
        }

        private void ValideOsParametros() {
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
    }
}