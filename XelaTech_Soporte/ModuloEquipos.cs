using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    internal class ModuloEquipos
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuEquipo, 4);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        RegistrarEquipo(xelaTech);
                        break;
                    case 2:
                        MostrarInformacionDeEquipo(xelaTech);
                        break;
                    case 3:

                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 3);
        }

        public static void OpcionesMenuEquipo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         GESTIÓN DE EQUIPOS       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Registrar un Equipo");
            Console.WriteLine("2. Consultar Información de un Equipo");
            Console.WriteLine("3. Regresar al Menú Principal");
            Console.ResetColor();
        }
        public static void ListaDeClientes(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("          LISTA DE CLIENTES        ");
            Console.WriteLine("====================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Cliente cliente in xelaTech.ListaClientes)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{xelaTech.ListaClientes.IndexOf(cliente) + 1}. Nombre: ");
                Console.ResetColor();
                Console.Write($"{cliente.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{cliente.Codigo}");
                Console.WriteLine();
            }
        }

        public static void OpcionesTraeCargador()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          ¿TRAE CARGADOR?           ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. SÍ");
            Console.WriteLine("2. NO");
            Console.ResetColor();
        }

        public static void RegistrarEquipo(XelaTech xelaTech)
        {
            if (xelaTech.ListaClientes.Count <= 0 || xelaTech.ListaClientes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningún Cliente Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionClienteSeleccionado = ValidarNumerico(1, ListaDeClientes, xelaTech, xelaTech.ListaClientes.Count);
                Cliente propietario = xelaTech.ListaClientes[posicionClienteSeleccionado - 1];
                int numeroTipoEquipo = MenuTipoDeEquipo();
                TipoEquipo tipoDeEquipo = (TipoEquipo)numeroTipoEquipo;
                bool traeCargador = false;
                string formatoGabinete = "";
                string tipoImpresion = "";
                if (tipoDeEquipo == TipoEquipo.Laptop)
                {
                    int numeroTraeCargador = ValidarNumerico(1, OpcionesTraeCargador, 2);
                    if (numeroTraeCargador == 1)
                    {
                        traeCargador = true;
                    }
                    else
                    {
                        traeCargador = false;
                    }
                }
                else if (tipoDeEquipo == TipoEquipo.PCEscritorio)
                {
                    formatoGabinete = ValidarTexto("Ingrese el formato del gabinete (Si aplica): ", 15);
                }
                else if (tipoDeEquipo == TipoEquipo.Impresora)
                {
                    tipoImpresion = ValidarTexto("Ingrese el tipo de impresión (Si aplica): ", 15);
                }
                string accesorios = ValidarTexto("Ingrese los accesorios del equipo (Si aplica): ", 50);
                string estadoFisico = ValidarTexto("Ingrese el estado físico del equipo: ", 50);
                string numeroSerie = ValidarTexto("Ingrese el número de serie: ", 15);
                string marca = ValidarTexto("Ingrese la marca: ", 15);
                string modelo = ValidarTexto("Ingrese el modelo: ", 15);
                if (tipoDeEquipo == TipoEquipo.Laptop)
                {
                    Laptop laptop = new Laptop(numeroSerie, marca, modelo, propietario, tipoDeEquipo, estadoFisico, accesorios, traeCargador);
                    xelaTech.IngresarEquipo(laptop);
                }
                else if (tipoDeEquipo == TipoEquipo.PCEscritorio)
                {
                    ComputadoraEscritorio pc = new ComputadoraEscritorio(numeroSerie, marca, modelo, propietario, tipoDeEquipo, estadoFisico, accesorios, formatoGabinete);
                    xelaTech.IngresarEquipo(pc);
                }
                else if (tipoDeEquipo == TipoEquipo.Impresora)
                {
                    Impresora impresora = new Impresora(numeroSerie, marca, modelo, propietario, tipoDeEquipo, estadoFisico, accesorios, tipoImpresion);
                    xelaTech.IngresarEquipo(impresora);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se Registro Correctamente el Equipo.");
                Console.ResetColor();
                LimpiarConsola();
            }
        }

        public static void ListaDeLaptos(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE LAPTOPS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Equipo equipo in xelaTech.ListaEquipos)
            {
                if (equipo is Laptop laptop)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{xelaTech.ListaEquipos.IndexOf(equipo) + 1}. Propietario: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Propietario.NombreCompleto} || ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Marca: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Marca} || ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"ID: ");
                    Console.ResetColor();
                    Console.Write($"({equipo.Codigo})");
                    Console.WriteLine();
                }
            }
        }

        public static void ListaDePC(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine("          LISTA DE PC de Escritorio        ");
            Console.WriteLine("============================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Equipo equipo in xelaTech.ListaEquipos)
            {
                if (equipo is ComputadoraEscritorio pc)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{xelaTech.ListaEquipos.IndexOf(equipo) + 1}. Propietario: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Propietario.NombreCompleto} || ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Marca: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Marca} || ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"ID: ");
                    Console.ResetColor();
                    Console.Write($"({equipo.Codigo})");
                    Console.WriteLine();
                }
            }
        }

        public static void ListaDeImpresoras(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("          LISTA DE IMPRESORAS        ");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Equipo equipo in xelaTech.ListaEquipos)
            {
                if (equipo is Impresora impresora)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{xelaTech.ListaEquipos.IndexOf(equipo) + 1}. Propietario: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Propietario.NombreCompleto} || ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Marca: ");
                    Console.ResetColor();
                    Console.Write($"{equipo.Marca} || ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"ID: ");
                    Console.ResetColor();
                    Console.Write($"({equipo.Codigo})");
                    Console.WriteLine();
                }
            }
        }

        public static void OpcionesMenuTipoDeEquipo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         MENÚ DE CONSULTAS       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Consultar Laptops");
            Console.WriteLine("2. Consultar Computadoras de Escritorio");
            Console.WriteLine("3. Consultar Impresoras");
            Console.WriteLine("4. volver a la Gestión de Equipos");
            Console.ResetColor();
        }

        public static void MostrarInformacionDeEquipo(XelaTech xelaTech)
        {
            if (xelaTech.ListaEquipos.Count == 0 || xelaTech.ListaEquipos == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningún Equipo Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                MenuTipos(xelaTech);
            }
        }

        public static void MenuTipos(XelaTech xelaTech)
        {
            int opcionMenu = ValidarNumerico(1, OpcionesMenuTipoDeEquipo, 4);
            int posicionEquipo = 0;
            int cantidadEquipos;
            if (opcionMenu == 1)
            {
                cantidadEquipos = 0;
                foreach (Equipo equipo in xelaTech.ListaEquipos)
                {
                    if (equipo is Laptop)
                    {
                        cantidadEquipos++;
                    }
                }
                if (cantidadEquipos <= 0)
                {
                    opcionMenu = -1;
                }
                else
                {
                    posicionEquipo = ValidarNumerico(1, ListaDeLaptos, xelaTech, cantidadEquipos);
                }
            }
            else if (opcionMenu == 2)
            {
                cantidadEquipos = 0;
                foreach (Equipo equipo in xelaTech.ListaEquipos)
                {
                    if (equipo is ComputadoraEscritorio)
                    {
                        cantidadEquipos++;
                    }
                }
                if (cantidadEquipos == 0)
                {
                    opcionMenu = -2;
                }
                else
                {
                    posicionEquipo = ValidarNumerico(1, ListaDePC, xelaTech, cantidadEquipos);
                }
            }
            else if (opcionMenu == 3)
            {
                cantidadEquipos = 0;
                foreach (Equipo equipo in xelaTech.ListaEquipos)
                {
                    if (equipo is Impresora)
                    {
                        cantidadEquipos++;
                    }
                }
                if (cantidadEquipos == 0)
                {
                    opcionMenu = -3;
                }
                else
                {
                    posicionEquipo = ValidarNumerico(1, ListaDeImpresoras, xelaTech, cantidadEquipos);
                }
            }
            else if (opcionMenu == 4)
            {
                return;
            }
            if (opcionMenu == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ninguna Laptop Registrada");
                Console.ResetColor();
                LimpiarConsola();
                MenuTipos(xelaTech);
                return;
            }
            else if (opcionMenu == -2)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ninguna PC de Escritorio Registrado");
                Console.ResetColor();
                LimpiarConsola();
                MenuTipos(xelaTech);
                return;
            }
            else if (opcionMenu == -3)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ninguna Impresora Registrada");
                Console.ResetColor();
                LimpiarConsola();
                MenuTipos(xelaTech);
                return;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            if (opcionMenu == 1)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("     INFORMACIÓN DE LA LAPTOP      ");
                Console.WriteLine("==================================");
            }
            else if (opcionMenu == 2)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("       INFORMACIÓN DE LA PC      ");
                Console.WriteLine("==================================");
            }
            else if (opcionMenu == 3)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("     INFORMACIÓN DE LA IMPRESORA    ");
                Console.WriteLine("====================================");
            }
            Console.WriteLine();
            Console.ResetColor();
            xelaTech.ListaEquipos[posicionEquipo - 1].MostrarDetalles();
            LimpiarConsola();
            MenuTipos(xelaTech);
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
