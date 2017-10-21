namespace AvaliacaoDeCandidatosApi.Models {
    public interface IConfiguracaoSmtp {
        string Servidor { get; set; }
        int Porta { get; set; }
        string Usuario { get; set; }
        string Senha { get; set; }
        bool UseSsl { get; set; }
        bool RequerAutenticacao { get; set; }
        string Encoding { get; set; } 
    }
}