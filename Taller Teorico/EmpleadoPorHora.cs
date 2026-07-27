using System;

namespace Taller_Teorico
{
    public class EmpleadoPorHora : Empleado
    {
        public decimal SueldoPorHora { get; private set; }
        public decimal HorasTrabajadas { get; private set; }

        public EmpleadoPorHora(string nombre, string id, decimal sueldoPorHora, decimal horasTrabajadas)
            : base(nombre, id)
        {
            if (sueldoPorHora <= 0) throw new ArgumentException("El sueldo por hora debe ser mayor que cero.");
            if (horasTrabajadas < 0) throw new ArgumentException("Las horas trabajadas no pueden ser negativas.");
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularSalario()
        {
            return SueldoPorHora * HorasTrabajadas;
        }

        public override string ToString()
        {
            return $"[PorHora] {Nombre} (ID: {ID}) - Sueldo por hora: {SueldoPorHora:C2}, Horas: {HorasTrabajadas}, Salario: {CalcularSalario():C2}";
        }
    }
}
