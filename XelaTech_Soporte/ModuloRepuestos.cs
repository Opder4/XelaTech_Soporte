using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    internal class ModuloRepuestos
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuRepuesto, 3);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        RegistrarRepuesto(xelaTech);
                        break;
                    case 2:
                        MostrarInformacionDeRepuesto(xelaTech);
                        break;
                    case 3:
                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 3);
        }

        public static void OpcionesMenuRepuesto()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("       GESTIÓN DE REPUESTOS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Registrar un Repuesto");
            Console.WriteLine("2. Consultar Información de Repuesto");
            Console.WriteLine("3. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void RegistrarRepuesto(XelaTech xelaTech)
        {
            string nombreRepuesto = ValidarTexto("Ingrese el nombre del repuesto: ", 35);
            string categoriaRepuesto = ValidarTexto("Ingrese la categoría (ej. Pantalla, RAM, Almacenamiento): ", 30);
            int existencia = ValidarNumerico("Ingrese la cantidad en existencia", 4, true);
            int existenciaMinima = ValidarNumerico("Ingrese la existencia mínima permitida", 4, true);
            double costoUnitario = ValidarPrecio("Ingrese el costo unitario del repuesto", 8);
            Repuesto repuesto = new Repuesto(nombreRepuesto, categoriaRepuesto, existencia, existenciaMinima, costoUnitario);
            xelaTech.IngresarRepuesto(repuesto);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registró Correctamente el Repuesto.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ListaDeRepuestos(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         LISTA DE REPUESTOS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Repuesto repuesto in xelaTech.ListaRepuestos)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{xelaTech.ListaRepuestos.IndexOf(repuesto) + 1}. Nombre: ");
                Console.ResetColor();
                Console.Write($"{repuesto.Nombre} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Cat: ");
                Console.ResetColor();
                Console.Write($"{repuesto.Categoria} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{repuesto.Codigo}");
                Console.WriteLine();
            }
        }

        public static void MostrarInformacionDeRepuesto(XelaTech xelaTech)
        {
            if (xelaTech.ListaRepuestos.Count == 0 || xelaTech.ListaRepuestos == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningún Repuesto Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionRepuesto = ValidarNumerico(1, ListaDeRepuestos, xelaTech, xelaTech.ListaRepuestos.Count);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("==================================");
                Console.WriteLine("     INFORMACIÓN DEL REPUESTO     ");
                Console.WriteLine("==================================");
                Console.WriteLine();
                Console.ResetColor();
                xelaTech.ListaRepuestos[posicionRepuesto - 1].MostrarInformacion();
                LimpiarConsola();
            }
        }

        public static void LimpiarConsola()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }

        public static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Error: opción no válida");
            Console.WriteLine();
            Console.ResetColor();
            LimpiarConsola();
        }
    }
}
