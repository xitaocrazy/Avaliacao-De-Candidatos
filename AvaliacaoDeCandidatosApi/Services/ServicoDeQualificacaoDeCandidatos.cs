using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Enuns;
using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public class ServicoDeQualificacaoDeCandidatos : IServicoDeQualificacaoDeCandidatos {
        public void QualifiqueCandidato(ICandidato candidato){
            VerifiqueSeCandidatoPossuiAlgumaQualificacao(candidato);
        }

        public List<Email> GetEmailDeRetorno(ICandidato candidato, string origem){
            var emails = new List<Email>();
            foreach(var qualificacao in candidato.Qualificacoes){
                switch(qualificacao){
                    case Qualificacao.backEnd:
                        emails.Add(GetEmailBackEnd(candidato.Email, origem));
                        break;
                    case Qualificacao.frontEnd:
                        emails.Add(GetEmailFrontEnd(candidato.Email, origem));
                        break;
                    case Qualificacao.mobile:
                        emails.Add(GetEmailMobile(candidato.Email, origem));
                        break;
                    case Qualificacao.nenhum:
                        emails.Add(GetEmailGenerico(candidato.Email, origem));
                        break;
                }
            }
            return emails;
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

        private Email GetEmailFrontEnd(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Front-End entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailBackEnd(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Back-End entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailMobile(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Mobile entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }

        private Email GetEmailGenerico(string destino, string origem){
            var email = new Email{
                Destino = destino,
                Origem = origem,
                Assunto = "Obrigado por se candidatar",
                MensagemDeTexto = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador entraremos em contato.",
                MensagemHtml = "",
                EncaminharPara = ""              
            };
            return email;
        }
    }
}