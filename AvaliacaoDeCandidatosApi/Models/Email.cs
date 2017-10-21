using System;

namespace AvaliacaoDeCandidatosApi.Models{
    public class Email : IEmail, IEquatable<Email>{
        public string Destino {get; set;}
        public string Origem {get; set;}
        public string Assunto {get; set;}
        public string MensagemDeTexto {get; set;}
        public string MensagemHtml {get; set;}
        public string EncaminharPara {get; set;}


        public override string ToString() {
            return $"Origem: {Origem} - Destino: {Destino} - Assunto: {Assunto}";
        }

        public bool Equals(Email other) {
            return other != null && 
            String.Equals(Destino, other.Destino) &&
            String.Equals(Origem, other.Origem)&&
            String.Equals(Assunto, other.Assunto) &&
            String.Equals(MensagemDeTexto, other.MensagemDeTexto)&&
            String.Equals(MensagemHtml, other.MensagemHtml) &&
            String.Equals(EncaminharPara, other.EncaminharPara);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Email) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Destino?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Origem?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Assunto?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MensagemDeTexto?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MensagemHtml?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ EncaminharPara?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        public static bool operator ==(Email a, Email b) {
            return Equals(a, b);
        }

        public static bool operator !=(Email a, Email b) {
            return !Equals(a, b);
        }
    }
}