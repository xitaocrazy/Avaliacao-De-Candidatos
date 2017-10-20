using AvaliacaoDeCandidatosApi.Models;

namespace AvaliacaoDeCandidatosApi.Services {
    public interface IServicoDeQualificacaoDeCandidatos {
        void QualifiqueCandidato(ICandidato candidato);
    }
}