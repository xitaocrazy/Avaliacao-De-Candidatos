namespace AvaliacaoDeCandidatosApi.Models {
    public class Candidato : ICandidato {
        public string Nome {get; set;} 
        public string Email {get; set;}
        public int HTML {get; set;}
        public int CSS {get; set;}
        public int Javascript {get; set;}
        public int Python {get; set;}
        public int Django {get; set;}
        public int Ios {get; set;}
        public int Android {get; set;}
    }
}