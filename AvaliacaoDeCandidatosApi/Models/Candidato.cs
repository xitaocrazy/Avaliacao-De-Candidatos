using System;
using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Enuns;

namespace AvaliacaoDeCandidatosApi.Models {
    public class Candidato : ICandidato, IEquatable<Candidato> {
        public string Nome {get; set;} 
        public string Email {get; set;}
        public int HTML {get; set;}
        public int CSS {get; set;}
        public int Javascript {get; set;}
        public int Python {get; set;}
        public int Django {get; set;}
        public int Ios {get; set;}
        public int Android {get; set;}
        public List<Qualificacao> Qualificacoes {get; set;}


        public override string ToString() {
            return $"Nome: {Nome} - Email: {Email}";
        }

        public bool Equals(Candidato other) {
            return other != null && 
            String.Equals(Nome, other.Nome) &&
            String.Equals(Email, other.Email)&&
            HTML == other.HTML &&
            CSS == other.CSS &&
            Javascript == other.Javascript &&
            Python == other.Python &&
            Django == other.Django &&            
            Ios == other.Ios &&
            Android == other.Android;
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
            return Equals((Candidato) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Nome?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Email?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ HTML.GetHashCode();
                hashCode = (hashCode * 397) ^ CSS.GetHashCode();
                hashCode = (hashCode * 397) ^ Javascript.GetHashCode();
                hashCode = (hashCode * 397) ^ Python.GetHashCode();
                hashCode = (hashCode * 397) ^ Django.GetHashCode();
                hashCode = (hashCode * 397) ^ Ios.GetHashCode();
                hashCode = (hashCode * 397) ^ Android.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Candidato a, Candidato b) {
            return Equals(a, b);
        }

        public static bool operator !=(Candidato a, Candidato b) {
            return !Equals(a, b);
        }
    }
}