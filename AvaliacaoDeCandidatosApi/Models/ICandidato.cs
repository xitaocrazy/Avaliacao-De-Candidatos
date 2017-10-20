using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Enuns;

namespace AvaliacaoDeCandidatosApi.Models {
    public interface ICandidato {
        string Nome {get; set;} 
        string Email {get; set;}
        int HTML {get; set;}
        int CSS {get; set;}
        int Javascript {get; set;}
        int Python {get; set;}
        int Django {get; set;}
        int Ios {get; set;}
        int Android {get; set;}
        List<Qualificacao> Qualificacoes {get; set;}
    }
}