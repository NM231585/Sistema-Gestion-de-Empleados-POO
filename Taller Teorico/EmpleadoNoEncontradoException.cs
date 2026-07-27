using System;

namespace Taller_Teorico
{
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException() { }
        public EmpleadoNoEncontradoException(string message) : base(message) { }
        public EmpleadoNoEncontradoException(string message, Exception inner) : base(message, inner) { }
    }
}
