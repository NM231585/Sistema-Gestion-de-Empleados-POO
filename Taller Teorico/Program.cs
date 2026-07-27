using System;
using System.Collections.Generic;

namespace Taller_Teorico
{
    internal class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("-- Sistema de Gestión de Empleados --");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Mostrar todos los empleados");
                Console.WriteLine("3. Buscar empleado por ID");
                Console.WriteLine("4. Eliminar empleado");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                var opt = Console.ReadLine();
                Console.WriteLine();
                switch (opt)
                {
                    case "1": AgregarEmpleado(); break;
                    case "2": MostrarEmpleados(); break;
                    case "3": BuscarEmpleado(); break;
                    case "4": EliminarEmpleado(); break;
                    case "5": salir = true; break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("Tipo de empleado:");
            Console.WriteLine("1. Empleado por hora");
            Console.WriteLine("2. Empleado asalariado");
            Console.WriteLine("3. Empleado comisionista");
            Console.Write("Seleccione tipo: ");
            var t = Console.ReadLine();
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine()?.Trim();
            Console.Write("ID: ");
            var id = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("El ID no puede estar vacío.");
                return;
            }
            if (empleados.Exists(e => e.ID.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ya existe un empleado con ese ID.");
                return;
            }

            try
            {
                switch (t)
                {
                    case "1":
                        var sueldoHora = LeerDecimalPositivo("Sueldo por hora: ");
                        var horas = LeerDecimalPositivo("Horas trabajadas: ");
                        empleados.Add(new EmpleadoPorHora(nombre, id, sueldoHora, horas));
                        Console.WriteLine("Empleado por hora agregado.");
                        break;
                    case "2":
                        var sueldoMensual = LeerDecimalPositivo("Sueldo mensual fijo: ");
                        empleados.Add(new EmpleadoAsalariado(nombre, id, sueldoMensual));
                        Console.WriteLine("Empleado asalariado agregado.");
                        break;
                    case "3":
                        var sueldoBase = LeerDecimalPositivo("Sueldo base: ");
                        var ventas = LeerDecimalPositivo("Ventas realizadas: ");
                        var porcentaje = LeerDecimalPositivo("Porcentaje de comisión (por ejemplo 10 para 10%): ");
                        empleados.Add(new EmpleadoComisionista(nombre, id, sueldoBase, ventas, porcentaje));
                        Console.WriteLine("Empleado comisionista agregado.");
                        break;
                    default:
                        Console.WriteLine("Tipo inválido.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada numérica inválida.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static decimal LeerDecimalPositivo(string prompt)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (!decimal.TryParse(s, out var val) || val <= 0)
            {
                throw new ArgumentException("El valor debe ser numérico y mayor que cero.");
            }
            return val;
        }

        static void MostrarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }
            foreach (var e in empleados)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void BuscarEmpleado()
        {
            Console.Write("ID a buscar: ");
            var id = Console.ReadLine()?.Trim();
            try
            {
                var e = ObtenerPorID(id);
                Console.WriteLine(e.ToString());
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EliminarEmpleado()
        {
            Console.Write("ID a eliminar: ");
            var id = Console.ReadLine()?.Trim();
            try
            {
                var e = ObtenerPorID(id);
                empleados.Remove(e);
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            catch (EmpleadoNoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static Empleado ObtenerPorID(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new EmpleadoNoEncontradoException("ID inválido.");
            var emp = empleados.Find(x => x.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (emp == null) throw new EmpleadoNoEncontradoException($"Empleado con ID '{id}' no encontrado.");
            return emp;
        }
    }
}
