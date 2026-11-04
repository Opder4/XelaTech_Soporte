using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloOrdenamientos
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuOrdenamientos, 4);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        OrdenarSolicitudesQuickSort(xelaTech, 0, xelaTech.ListaTodasSolicitudes.Count - 1);
                        MostrarSolicitudesOrdenadasPorCosto(xelaTech);
                        break;
                    case 2:
                        OrdenarSolicitudesShellSort(xelaTech);
                        MostrarSolicitudesOrdenadasPorFecha(xelaTech);
                        break;
                    case 3:
                        OrdenarRepuestosBubbleSort(xelaTech);
                        MostrarRepuestosOrdenados(xelaTech);
                        break;
                    case 4:

                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 4);
        }

        public static void OpcionesMenuOrdenamientos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("      MÓDULO DE ORDENAMIENTOS      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Solicitudes por Costo Total (Quick Sort - Mayor a Menor)");
            Console.WriteLine("2. Solicitudes por Fecha (Shell Sort - Más antiguas primero)");
            Console.WriteLine("3. Repuestos por Existencia (Bubble Sort - Menor a Mayor)");
            Console.WriteLine("4. Regresar al Menú Principal");
            Console.ResetColor();
        }

        private static void OrdenarSolicitudesQuickSort(XelaTech xelaTech, int inicio, int fin)
        {
            if (inicio < fin)
            {
                int indiceParticion = ParticionarCosto(xelaTech.ListaTodasSolicitudes, inicio, fin);
                OrdenarSolicitudesQuickSort(xelaTech, inicio, indiceParticion - 1);
                OrdenarSolicitudesQuickSort(xelaTech, indiceParticion + 1, fin);
            }
        }

        private static int ParticionarCosto(List<Solicitud> lista, int inicio, int fin)
        {
            double pivote = lista[fin].CostoTotal;
            int i = inicio - 1;
            for (int j = inicio; j < fin; j++)
            {
                if (lista[j].CostoTotal > pivote)
                {
                    i++;
                    Solicitud temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }
            Solicitud tempFinal = lista[i + 1];
            lista[i + 1] = lista[fin];
            lista[fin] = tempFinal;
            return i + 1;
        }

        private static void OrdenarSolicitudesShellSort(XelaTech xelaTech)
        {
            int n = xelaTech.ListaTodasSolicitudes.Count;
            for (int brecha = n / 2; brecha > 0; brecha /= 2)
            {
                for (int i = brecha; i < n; i += 1)
                {
                    Solicitud temp = xelaTech.ListaTodasSolicitudes[i];
                    int j;
                    for (j = i; j >= brecha && xelaTech.ListaTodasSolicitudes[j - brecha].FechaRecepcion > temp.FechaRecepcion; j -= brecha)
                    {
                        xelaTech.ListaTodasSolicitudes[j] = xelaTech.ListaTodasSolicitudes[j - brecha];
                    }
                    xelaTech.ListaTodasSolicitudes[j] = temp;
                }
            }
        }

        private static void OrdenarRepuestosBubbleSort(XelaTech xelaTech)
        {
            int n = xelaTech.ListaRepuestos.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (xelaTech.ListaRepuestos[j].Existencia > xelaTech.ListaRepuestos[j + 1].Existencia)
                    {
                        Repuesto temp = xelaTech.ListaRepuestos[j];
                        xelaTech.ListaRepuestos[j] = xelaTech.ListaRepuestos[j + 1];
                        xelaTech.ListaRepuestos[j + 1] = temp;
                    }
                }
            }
        }

        private static void MostrarSolicitudesOrdenadasPorCosto(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" SOLICITUDES ORDENADAS POR COSTO   ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            foreach (Solicitud solicitudes in xelaTech.ListaTodasSolicitudes)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"ID: {solicitudes.Codigo} | ");
                Console.ResetColor();
                Console.WriteLine($"{ColorConsola.Verde}Costo Total: Q.{ColorConsola.Reset} {solicitudes.CostoTotal:F2} | {ColorConsola.Azul}Estado:{ColorConsola.Reset} {solicitudes.EstadoActual}");
            }
            LimpiarConsola();
        }

        private static void MostrarSolicitudesOrdenadasPorFecha(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" SOLICITUDES ORDENADAS POR FECHA   ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"ID: {solicitud.Codigo} | ");
                Console.ResetColor();
                Console.WriteLine($"{ColorConsola.Verde}Fecha:{ColorConsola.Reset} {solicitud.FechaRecepcion} | {ColorConsola.Azul}Cliente:{ColorConsola.Reset} {solicitud.Cliente.NombreCompleto}");
            }
            LimpiarConsola();
        }

        private static void MostrarRepuestosOrdenados(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" REPUESTOS ORDENADOS POR EXISTENCIA");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            foreach (Repuesto repuesto in xelaTech.ListaRepuestos)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"ID: {repuesto.Codigo} | ");
                Console.ResetColor();
                Console.WriteLine($"{ColorConsola.Verde}Existencia:{ColorConsola.Reset} {repuesto.Existencia} | {ColorConsola.Azul}Nombre:{ColorConsola.Reset} {repuesto.Nombre}");
            }
            LimpiarConsola();
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
