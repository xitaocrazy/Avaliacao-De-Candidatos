using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Enuns;
using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public class ServicoDeQualificacaoDeCandidatos {
        public void QualifiqueCandidato(ICandidato candidato){
            VerifiqueSeCandidatoPossuiAlgumaQualificacao(candidato);
        }

        private void VerifiqueSeCandidatoEhQualificadoParaFrontEnd(ICandidato candidato){
            if (candidato.HTML >= 7 && candidato.CSS >= 7 && candidato.Javascript >= 7){
                candidato.Qualificacoes.Add(Qualificacao.frontEnd);
            }
        } 

        private void VerifiqueSeCandidatoEhQualificadoParaBackEnd(ICandidato candidato){
            if (candidato.Python >= 7 && candidato.Django >= 7){
                candidato.Qualificacoes.Add(Qualificacao.backEnd);
            }
        }

        private void VerifiqueSeCandidatoEhQualificadoParaMobile(ICandidato candidato){
            if (candidato.Ios >= 7 || candidato.Android >= 7){
                candidato.Qualificacoes.Add(Qualificacao.mobile);
            }
        }

        private void VerifiqueSeCandidatoPossuiAlgumaQualificacao(ICandidato candidato){
            candidato.Qualificacoes = new List<Qualificacao>();
            VerifiqueSeCandidatoEhQualificadoParaFrontEnd(candidato);
            VerifiqueSeCandidatoEhQualificadoParaBackEnd(candidato);
            VerifiqueSeCandidatoEhQualificadoParaMobile(candidato);
            if (candidato.Qualificacoes.Count == 0){
                candidato.Qualificacoes.Add(Qualificacao.nenhum);
            }
        }
    }
}