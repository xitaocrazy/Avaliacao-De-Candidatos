using System.Collections.Generic;
using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeQualificacaoDeCandidatos {
        void QualifiqueCandidato(ICandidato candidato);

        IList<IEmail> GetEmailDeRetorno(ICandidato candidato, string origem);
    }
}