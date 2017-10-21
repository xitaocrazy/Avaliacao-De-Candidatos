using System;
using System.Runtime.Serialization;

namespace AvaliacaoDeCandidatosApi.Exceptions {
    public class EnvioDeEmailException : Exception {
        public EnvioDeEmailException() {}
        public EnvioDeEmailException(string message) : base(message) {}
        public EnvioDeEmailException(string message, Exception inner) : base(message, inner) {}
        protected EnvioDeEmailException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}