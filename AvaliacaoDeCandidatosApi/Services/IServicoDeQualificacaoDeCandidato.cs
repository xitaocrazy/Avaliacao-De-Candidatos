using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeQualificacaoDeCandidatos {
        void QualifiqueCandidato(ICandidato candidato);

        List<Email> GetEmailDeRetorno(ICandidato candidato, string origem);
    }
}