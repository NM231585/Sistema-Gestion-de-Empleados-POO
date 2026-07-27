using System;

namespace Taller_Teorico
{
    public abstract class Empleado
    {
        private string nombre;
        private string id;

        public string Nombre
        {
            get => nombre;
            set => nombre = value ?? string.Empty;
        }

        public string ID
        {
            get => id;
            private set => id = value ?? string.Empty;
        }

        protected Empleado(string nombre, string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("El ID no puede estar vacío.");
            Nombre = nombre;
            ID = id;
        }

        public abstract decimal CalcularSalario();

        public override string ToString()
        {
            return $"Nombre: {Nombre}, ID: {ID}, Salario: {CalcularSalario():C2}";
        }
    }
}
