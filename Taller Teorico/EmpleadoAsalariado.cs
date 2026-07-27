using System;

namespace Taller_Teorico
{
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SueldoMensual { get; private set; }

        public EmpleadoAsalariado(string nombre, string id, decimal sueldoMensual)
            : base(nombre, id)
        {
            if (sueldoMensual <= 0) throw new ArgumentException("El sueldo mensual debe ser mayor que cero.");
            SueldoMensual = sueldoMensual;
        }

        public override decimal CalcularSalario()
        {
            return SueldoMensual;
        }

        public override string ToString()
        {
            return $"[Asalariado] {Nombre} (ID: {ID}) - Sueldo mensual: {SueldoMensual:C2}, Salario: {CalcularSalario():C2}";
        }
    }
}
