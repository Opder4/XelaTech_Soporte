using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloClientes
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuCliente, 4);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        RegistrarCliente(xelaTech);
                        break;
                    case 2:
                        MostrarInformacionDeCliente(xelaTech);
                        break;
                    case 3:
                        ModificarInformacionDeCliente(xelaTech);
                        break;
                    case 4:

                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 4);
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
        public static void OpcionesMenuCliente()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         GESTIÓN DE CLIENTES       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Registrar un Cliente");
            Console.WriteLine("2. Consultar Información de Cliente");
            Console.WriteLine("3. Actualizar Información de Cliente");
            Console.WriteLine("4. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void RegistrarCliente(XelaTech xelaTech)
        {
            string nombreCompletoCliente = ValidarTexto("Ingrese el nombre completo: ", 35);
            int numeroTelefonoCliente = ValidarTelefono();
            string correoElectronicoCliente = ValidarCorreo();
            int numeroTipoCliente = MenuTipoDeCliente();
            TipoCliente tipoCliente = (TipoCliente)numeroTipoCliente;
            Cliente cliente = new Cliente(nombreCompletoCliente, numeroTelefonoCliente, correoElectronicoCliente, tipoCliente);
            xelaTech.IngresarCliente(cliente);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registro Correctamente al Cliente.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ListaDeClientes(XelaTech xelaTech)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE CLIENTES        ");
            Console.WriteLine("===================================");
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

        public static void MostrarInformacionDeCliente(XelaTech xelaTech)
        {
            if (xelaTech.ListaClientes.Count == 0 || xelaTech.ListaClientes == null)
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
                int posionCliente = ValidarNumerico(1, ListaDeClientes, xelaTech, xelaTech.ListaClientes.Count);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("==================================");
                Console.WriteLine("     INFORMACIÓN DEL CLIENTE      ");
                Console.WriteLine("==================================");
                Console.WriteLine();
                Console.ResetColor();
                xelaTech.ListaClientes[posionCliente - 1].MostrarInformacion();
                LimpiarConsola();
            }
        }

        public static void OpcionesMenuModificacionCliente(Cliente cliente)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"        MENÚ CLIENTE  ({cliente.Codigo})   ");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Modificar el Número de Teléfono");
            Console.WriteLine("2. Modificar el Correo Electrónico");
            Console.WriteLine("3. Modificar el Nombre ");
            Console.WriteLine("4. Regresar a Gestión de Clientes");
            Console.ResetColor();
        }

        public static void MenuModificacionCliente(Cliente cliente)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuModificacionCliente, cliente, 4);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:
                        ModificarNumeroDeTelefono(cliente);
                        break;
                    case 2:
                        ModificarCorreoElectronico(cliente);
                        break;
                    case 3:
                        ModificarNombreDeCliente(cliente);
                        break;
                    case 4:

                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 4);
        }

        public static void ModificarNumeroDeTelefono(Cliente cliente)
        {
            int nuevoNumueroTelefono = ValidarTelefono();
            cliente.Telefono = nuevoNumueroTelefono;
        }

        public static void ModificarCorreoElectronico(Cliente cliente)
        {
            string nuevoCorreo = ValidarCorreo();
            cliente.Correo = nuevoCorreo;
        }

        public static void ModificarNombreDeCliente(Cliente cliente)
        {
            string nuevoNombre = ValidarTexto("Ingrese el nuevo nombre: ", 35);
            cliente.NombreCompleto = nuevoNombre;
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

        public static void ModificarInformacionDeCliente(XelaTech xelaTech)
        {
            if (xelaTech.ListaClientes.Count == 0 || xelaTech.ListaClientes == null)
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
                int posionCliente = ValidarNumerico(1, ListaDeClientes, xelaTech, xelaTech.ListaClientes.Count);
                Console.WriteLine();
                MenuModificacionCliente(xelaTech.ListaClientes[posionCliente - 1]);
            }
        }
    }
}
