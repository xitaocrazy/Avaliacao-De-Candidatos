namespace AvaliacaoDeCandidatosApi.Models {
    public class ConfiguracaoSmtp : IConfiguracaoSmtp {
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool UseSsl { get; set; }
        public bool RequerAutenticacao { get; set; }
        public string Encoding { get; set; } 
    }
}