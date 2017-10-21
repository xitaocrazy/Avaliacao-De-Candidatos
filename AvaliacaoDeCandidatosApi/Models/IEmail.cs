namespace AvaliacaoDeCandidatosApi.Models{
    public interface IEmail{
        string Destino {get; set;}
        string Origem {get; set;}
        string Assunto {get; set;}
        string MensagemDeTexto {get; set;}
        string MensagemHtml {get; set;}
        string EncaminharPara {get; set;}
    }
}