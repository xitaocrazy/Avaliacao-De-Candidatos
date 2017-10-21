using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Models {
    public class ConfiguracaoSmtp : IConfiguracaoSmtp {
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool UseSsl { get; set; }
        public bool RequerAutenticacao { get; set; }
        public string Encoding { get; set; } 

        public ConfiguracaoSmtp (IConfiguration configuracao){
            Servidor = configuracao["ConfiguracaoSmtp:Servidor"];
            Porta = int.Parse(configuracao["ConfiguracaoSmtp:Porta"]);
            Usuario = configuracao["ConfiguracaoSmtp:Usuario"];
            Senha = configuracao["ConfiguracaoSmtp:Senha"];
            UseSsl = bool.Parse(configuracao["ConfiguracaoSmtp:UseSsl"]);
            RequerAutenticacao = bool.Parse(configuracao["ConfiguracaoSmtp:RequerAutenticacao"]);
            Encoding = configuracao["ConfiguracaoSmtp:Encoding"];
        }
    }
}