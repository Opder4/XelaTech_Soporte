using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    internal class ModuloTecnicos
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuTecnico, 4);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        RegistrarTecnico(xelaTech);
                        break;
                    case 2:
                        MostrarInformacionDeTecnico(xelaTech);
                        break;
                    case 3:
                        
                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 3);
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

        public static void OpcionesMenuTecnico()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         GESTIÓN DE TÉCNICOS       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Registrar un Cliente");
            Console.WriteLine("2. Consultar Información de Técnico - Cambio de Disponiblidad");
            Console.WriteLine("3. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void RegistrarTecnico(XelaTech xelaTech)
        {
            string nombreCompletoTecnico = ValidarTexto("Ingrese el nombre completo: ", 35);
            int numeroEspecialidadTecnico = MenuEspecialidadTecnico();
            int numeroEstadoTecnico = MenuEstadoTecnico();
            EspecialidadTecnico especialidadTecnico = (EspecialidadTecnico)numeroEspecialidadTecnico;
            EstadoTecnico estadoTecnico = (EstadoTecnico)numeroEstadoTecnico;
            Tecnico tecnico = new Tecnico(nombreCompletoTecnico, especialidadTecnico, estadoTecnico);
            xelaTech.IngresarTecnico(tecnico);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registro Correctamente al Técnico.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ListaDeTecnicos(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE TÉCNICOS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Tecnico tecnico in xelaTech.ListaTecnicos)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{xelaTech.ListaTecnicos.IndexOf(tecnico) + 1}. Nombre: ");
                Console.ResetColor();
                Console.Write($"{tecnico.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{tecnico.Codigo}");
                Console.WriteLine();
            }
        }

        public static void MostrarInformacionDeTecnico(XelaTech xelaTech)
        {
            if (xelaTech.ListaTecnicos.Count == 0 || xelaTech.ListaTecnicos == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningún Técnico Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionTecnico = ValidarNumerico(1, ListaDeTecnicos, xelaTech, xelaTech.ListaTecnicos.Count);
                MostrarInformacionTecnico(xelaTech, posicionTecnico);
            }
        }

        public static void OpcionesEstadoInactivo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1. Cambiar Estado a Disponible");
            Console.WriteLine("2. Regresar a Gestión de Técnicos");
            Console.ResetColor();
        }

        public static void OpcionesEstadoDisponible()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1. Cambiar Estado a No disponible");
            Console.WriteLine("2. Regresar a Gestión de Técnicos");
            Console.ResetColor();
        }

        public static void MostrarInformacionTecnico(XelaTech xelaTech, int posicionTecnico)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("     INFORMACIÓN DEL TÉCNICO      ");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.ResetColor();
            Tecnico tecnicoSeleccionado = xelaTech.ListaTecnicos[posicionTecnico - 1];
            tecnicoSeleccionado.MostrarInformacion();
            int opcionMenu = 0;
            if (tecnicoSeleccionado.Estado == EstadoTecnico.Inactivo)
            {
                Console.WriteLine();
                Console.WriteLine();
                opcionMenu = ValidarNumericoSinLimpiarConsola(1, OpcionesEstadoInactivo, 2);
                switch (opcionMenu)
                {
                    case 1:
                        tecnicoSeleccionado.Estado = EstadoTecnico.Disponible;
                        Console.Clear();
                        MostrarInformacionTecnico(xelaTech, posicionTecnico);
                        break;
                    case 2:

                        break;
                    default:
                        Error();
                        break;
                }
            }
            else if (tecnicoSeleccionado.Estado == EstadoTecnico.Disponible)
            {
                Console.WriteLine();
                Console.WriteLine();
                opcionMenu = ValidarNumericoSinLimpiarConsola(1, OpcionesEstadoDisponible, 2);
                switch (opcionMenu)
                {
                    case 1:
                        tecnicoSeleccionado.Estado = EstadoTecnico.Inactivo;
                        Console.Clear();
                        MostrarInformacionTecnico(xelaTech, posicionTecnico);
                        break;
                    case 2:

                        break;
                    default:
                        Error();
                        break;
                }
            }
            else if (tecnicoSeleccionado.Estado == EstadoTecnico.Ocupado)
            {
                LimpiarConsola();
            }
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
