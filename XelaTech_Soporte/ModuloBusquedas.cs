using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloBusquedas
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuBusquedas, 5);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        BuscarClienteBinaria(xelaTech);
                        break;
                    case 2:
                        BuscarRepuestoBinaria(xelaTech);
                        break;
                    case 3:
                        BuscarTecnicoSecuencial(xelaTech);
                        break;
                    case 4:
                        BuscarEquipoSecuencial(xelaTech);
                        break;
                    case 5:

                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 5);
        }

        public static void OpcionesMenuBusquedas()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        MÓDULO DE BÚSQUEDAS        ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Búsqueda Binaria: Cliente por ID (Ej. CLI-001)");
            Console.WriteLine("2. Búsqueda Binaria: Repuesto por ID (Ej. REP-001)");
            Console.WriteLine("3. Búsqueda Secuencial: Técnico por Nombre");
            Console.WriteLine("4. Búsqueda Secuencial: Equipo por Marca");
            Console.WriteLine("5. Regresar al Menú Principal");
            Console.ResetColor();
        }

        private static void BuscarClienteBinaria(XelaTech xelaTech)
        {
            string idBuscado = ValidarAlfanumerico("Ingrese el ID del Cliente a buscar (Ej. CLI-001): ", 7).ToUpper();
            int inicio = 0;
            int fin = xelaTech.ListaClientes.Count - 1;
            Cliente clienteEncontrado = null;
            while (inicio <= fin)
            {
                int medio = inicio + (fin - inicio) / 2;
                int comparacion = string.Compare(xelaTech.ListaClientes[medio].Codigo, idBuscado);
                if (comparacion == 0)
                {
                    clienteEncontrado = xelaTech.ListaClientes[medio];
                    break;
                }
                if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        RESULTADO DE BÚSQUEDA      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            if (clienteEncontrado != null)
            {
                clienteEncontrado.MostrarInformacion();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró ningún Cliente con el ID proporcionado.");
                Console.ResetColor();
            }
            LimpiarConsola();
        }

        private static void BuscarRepuestoBinaria(XelaTech xelaTech)
        {
            string idBuscado = ValidarAlfanumerico("Ingrese el ID del Repuesto a buscar (Ej. REP-001): ", 7).ToUpper();
            int inicio = 0;
            int fin = xelaTech.ListaRepuestos.Count - 1;
            Repuesto repuestoEncontrado = null;
            while (inicio <= fin)
            {
                int medio = inicio + (fin - inicio) / 2;
                int comparacion = string.Compare(xelaTech.ListaRepuestos[medio].Codigo, idBuscado);
                if (comparacion == 0)
                {
                    repuestoEncontrado = xelaTech.ListaRepuestos[medio];
                    break;
                }
                if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        RESULTADO DE BÚSQUEDA      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            if (repuestoEncontrado != null)
            {
                repuestoEncontrado.MostrarInformacion();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró ningún Repuesto con el ID proporcionado.");
                Console.ResetColor();
            }
            LimpiarConsola();
        }

        private static void BuscarTecnicoSecuencial(XelaTech xelaTech)
        {
            string nombreBuscado = ValidarTexto("Ingrese el nombre del Técnico a buscar: ", 35).ToLower();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        RESULTADOS DE BÚSQUEDA     ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            bool encontrado = false;
            foreach (Tecnico tecnico in xelaTech.ListaTecnicos)
            {
                if (tecnico.NombreCompleto.ToLower().Contains(nombreBuscado))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                    tecnico.MostrarInformacion();
                    Console.WriteLine();
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontraron Técnicos que coincidan con la búsqueda.");
                Console.ResetColor();
            }
            LimpiarConsola();
        }

        private static void BuscarEquipoSecuencial(XelaTech xelaTech)
        {
            string marcaBuscada = ValidarTexto("Ingrese la marca del Equipo a buscar: ", 15).ToLower();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        RESULTADOS DE BÚSQUEDA     ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            bool encontrado = false;
            foreach (Equipo equipo in xelaTech.ListaEquipos)
            {
                if (equipo.Marca.ToLower().Contains(marcaBuscada))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                    equipo.MostrarDetalles();
                    Console.WriteLine();
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontraron Equipos de esa marca.");
                Console.ResetColor();
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
