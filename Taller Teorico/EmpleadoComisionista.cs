using System;

namespace Taller_Teorico
{
    public class EmpleadoComisionista : Empleado
    {
        public decimal SueldoBase { get; private set; }
        public decimal VentasRealizadas { get; private set; }
        public decimal PorcentajeComision { get; private set; }

        public EmpleadoComisionista(string nombre, string id, decimal sueldoBase, decimal ventasRealizadas, decimal porcentajeComision)
            : base(nombre, id)
        {
            if (sueldoBase < 0) throw new ArgumentException("El sueldo base no puede ser negativo.");
            if (ventasRealizadas < 0) throw new ArgumentException("Las ventas no pueden ser negativas.");
            if (porcentajeComision < 0) throw new ArgumentException("El porcentaje de comisión no puede ser negativo.");
            SueldoBase = sueldoBase;
            VentasRealizadas = ventasRealizadas;
            PorcentajeComision = porcentajeComision;
        }

        public override decimal CalcularSalario()
        {
            return SueldoBase + (VentasRealizadas * PorcentajeComision / 100m);
        }

        public override string ToString()
        {
            return $"[Comisionista] {Nombre} (ID: {ID}) - Sueldo base: {SueldoBase:C2}, Ventas: {VentasRealizadas:C2}, Comisión: {PorcentajeComision}% , Salario: {CalcularSalario():C2}";
        }
    }
}
