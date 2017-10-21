using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AvaliacaoDeCandidatosApi.Models {
    public class ConfiguracaoSmtp : IConfiguracaoSmtp, IEquatable<ConfiguracaoSmtp> {
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool UseSsl { get; set; }
        public bool RequerAutenticacao { get; set; }
        public string Encoding { get; set; } 
                

        public override string ToString() {
            return $"Servidor: {Servidor} - Porta: {Porta}";
        }

        public bool Equals(ConfiguracaoSmtp other) {
            return other != null && 
            String.Equals(Servidor, other.Servidor) &&            
            Porta == other.Porta &&
            String.Equals(Usuario, other.Usuario)&&
            String.Equals(Senha, other.Senha)&&
            UseSsl == other.UseSsl &&
            RequerAutenticacao == other.RequerAutenticacao &&
            String.Equals(Encoding, other.Encoding);
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
            return Equals((ConfiguracaoSmtp) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Servidor?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Porta.GetHashCode();
                hashCode = (hashCode * 397) ^ Usuario?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Senha?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ UseSsl.GetHashCode();
                hashCode = (hashCode * 397) ^ RequerAutenticacao.GetHashCode();
                hashCode = (hashCode * 397) ^ Encoding?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        public static bool operator ==(ConfiguracaoSmtp a, ConfiguracaoSmtp b) {
            return Equals(a, b);
        }

        public static bool operator !=(ConfiguracaoSmtp a, ConfiguracaoSmtp b) {
            return !Equals(a, b);
        }
    }
}