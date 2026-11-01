using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloSolicitudes
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuSolicitudes, 5);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1: 
                        RegistrarSolicitud(xelaTech); 
                        break;
                    case 2: 
                        ActualizarEstadoSolicitud(xelaTech); 
                        break;
                    case 3:
                        DeshacerEstadoSolicitud(xelaTech); 
                        break;
                    case 4:
                        MostrarInformacionDeSolicitud(xelaTech); 
                        break;
                    case 5: 

                        break;
                    default: 
                        Error();
                        break;
                }
            } while (opcionMenu != 5);
        }

        public static void OpcionesMenuSolicitudes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("       GESTIÓN DE SOLICITUDES      ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Registrar una Solicitud");
            Console.WriteLine("2. Actualizar Estado de una Solicitud");
            Console.WriteLine("3. Deshacer Estado de una Solicitud");
            Console.WriteLine("4. Consultar Información de Solicitud");
            Console.WriteLine("5. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void ListaDeSolicitudes(XelaTech xelaTech)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        LISTA DE SOLICITUDES       ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            for (int i = 0; i < xelaTech.ListaTodasSolicitudes.Count; i++)
            {
                Console.WriteLine();
                Solicitud solicitud = xelaTech.ListaTodasSolicitudes[i];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.Write($"ID: {solicitud.Codigo} | Cliente: {solicitud.Cliente.NombreCompleto} | Estado: {solicitud.EstadoActual}");
            }
        }

        public static void RegistrarSolicitud(XelaTech xelaTech)
        {
            if (xelaTech.ListaClientes.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay clientes registrados.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            int posicionCliente = ValidarNumericoMenusGrandes(3, () => ModuloClientes.ListaDeClientes(xelaTech), xelaTech.ListaClientes.Count);
            Cliente clienteSeleccionado = xelaTech.ListaClientes[posicionCliente - 1];
            List<Equipo> equiposCliente = xelaTech.ListaEquipos.Where(equipo => equipo.Propietario == clienteSeleccionado).ToList();
            if (equiposCliente.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El cliente seleccionado no tiene equipos registrados.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            int posicionEquipo = ValidarNumericoMenusGrandes(3, () => {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===================================");
                Console.WriteLine("        EQUIPOS DEL CLIENTE         ");
                Console.WriteLine("===================================\n");
                Console.ResetColor();
                for (int i = 0; i < equiposCliente.Count; i++)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{i + 1}. ");
                    Console.ResetColor();
                    Console.Write($"Marca: {equiposCliente[i].Marca} | ID: ({equiposCliente[i].Codigo})");
                }
            }, equiposCliente.Count);
            Equipo equipoSeleccinado = equiposCliente[posicionEquipo - 1];
            string descripcion = ValidarTexto("Ingrese la descripción del problema: ", 100);
            int posicionPrioridad = ValidarNumerico(1, () => {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.WriteLine("Elija la Prioridad de la Solicitud\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Normal");
                Console.WriteLine("2. Urgente");
                Console.ResetColor();
            }, 2);
            PrioridadSolicitud prioridad = (PrioridadSolicitud)posicionPrioridad;
            Solicitud nuevaSolicitud = new Solicitud(clienteSeleccionado, equipoSeleccinado, descripcion, prioridad);
            xelaTech.IngresarSolicitud(nuevaSolicitud);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Se registró la solicitud (RECIBIDA).");
            nuevaSolicitud.ActualizarEstado(EstadoSolicitud.EnEspera);
            nuevaSolicitud.Cliente.SolicitudesRegistradas += 1;
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ActualizarEstadoSolicitud(XelaTech xelaTech)
        {
            if (xelaTech.ListaTodasSolicitudes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No hay solicitudes registradas.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            int posicion = ValidarNumericoMenusGrandes(3, () => ListaDeSolicitudes(xelaTech), xelaTech.ListaTodasSolicitudes.Count);
            Solicitud solicitud = xelaTech.ListaTodasSolicitudes[posicion - 1];
            if (solicitud.EstadoActual == EstadoSolicitud.Entregada || solicitud.EstadoActual == EstadoSolicitud.Cancelada)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"La solicitud ya se encuentra {solicitud.EstadoActual} y su proceso ha finalizado.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            if (solicitud.EstadoActual == EstadoSolicitud.EnEspera)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("La solicitud se encuentra EN ESPERA.");
                Console.WriteLine("Debe asignarla a un técnico desde el módulo 'Atención de Solicitudes' antes de poder actualizarla.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            EstadoSolicitud siguienteEstado = (EstadoSolicitud)((int)solicitud.EstadoActual + 1);
            int opcionActualizar = ValidarNumerico(1, () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine($"    ACTUALIZAR SOLICITUD ({solicitud.Codigo})");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Estado Actual: {solicitud.EstadoActual}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine($"1. Avanzar al siguiente paso: {siguienteEstado}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Cancelar esta solicitud (Estado: Cancelada)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("3. Regresar a Gestión de Solicitudes");
                Console.ResetColor();
            }, 3);
            if (opcionActualizar == 3) return;
            if (opcionActualizar == 2)
            {
                solicitud.ActualizarEstado(EstadoSolicitud.Cancelada);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("La solicitud ha sido CANCELADA exitosamente.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            if (siguienteEstado == EstadoSolicitud.EnReparacion)
            {
                if (xelaTech.ListaRepuestos.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("El inventario de repuestos está vacío. Registre repuestos antes de pasar a reparación.");
                    Console.ResetColor();
                    LimpiarConsola();
                    return;
                }
                string diagnostico = ValidarTexto("Ingrese el diagnóstico del problema: ", 100);
                bool agregando = true;
                List<Repuesto> repuestosTemporales = new List<Repuesto>();
                while (agregando)
                {
                    Console.Clear();
                    int repuestoPosicion = ValidarNumerico(1, () => {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine();
                        Console.WriteLine("Seleccione los repuestos a utilizar para la reparación:");
                        Console.WriteLine();
                        Console.ResetColor();
                        ModuloRepuestos.ListaDeRepuestos(xelaTech);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine();
                        Console.WriteLine($"{xelaTech.ListaRepuestos.Count + 1}. Finalizar selección y AVANZAR a En Reparación");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{xelaTech.ListaRepuestos.Count + 2}. CANCELAR actualización y regresar");
                        Console.ResetColor();
                    }, xelaTech.ListaRepuestos.Count + 2);
                    if (repuestoPosicion == xelaTech.ListaRepuestos.Count + 1)
                    {
                        agregando = false;
                    }
                    else if (repuestoPosicion == xelaTech.ListaRepuestos.Count + 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Actualización cancelada. No se han modificado inventarios ni estados.");
                        Console.ResetColor();
                        LimpiarConsola();
                        return;
                    }
                    else
                    {
                        Repuesto repuestoSeleccionado = xelaTech.ListaRepuestos[repuestoPosicion - 1];
                        int yaEnLista = repuestosTemporales.Count(repuesto => repuesto == repuestoSeleccionado);
                        int stockDisponible = repuestoSeleccionado.Existencia - yaEnLista;
                        if (stockDisponible <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine($"Se agotó el stock disponible de {repuestoSeleccionado.Nombre}.");
                            Console.ResetColor();
                            LimpiarConsola();
                            continue;
                        }
                        int cantidad = ValidarNumerico($"Cantidad de '{repuestoSeleccionado.Nombre}' a usar (Disponibles: {stockDisponible})", 4, true);
                        if (cantidad > stockDisponible)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("No hay existencias suficientes. ¿Desea cancelar TODA la actualización? (Yes/No)");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();
                            if (respuesta == "yes")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Actualización abortada por falta de repuestos.");
                                Console.ResetColor();
                                LimpiarConsola();
                                return;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < cantidad; i++)
                            {
                                repuestosTemporales.Add(repuestoSeleccionado);
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            Console.WriteLine($"Se separaron {cantidad} '{repuestoSeleccionado.Nombre}'(s) para esta reparación.");
                            Console.ResetColor();
                            LimpiarConsola();
                        }
                    }
                }
                solicitud.Diagnostico = diagnostico;
                foreach (Repuesto repuesto in repuestosTemporales)
                {
                    repuesto.Existencia -= 1;
                    solicitud.RepuestosUsados.Add(repuesto);
                }
            }
            else if (siguienteEstado == EstadoSolicitud.ListaParaEntregar)
            {
                double costoManoObra = ValidarPrecio("Ingrese el costo de Mano de Obra para esta reparación", 8);
                solicitud.ManoDeObra = costoManoObra;
                solicitud.TecnicoAsignado.TrabajosActivos -= 1;
            }
            solicitud.ActualizarEstado(siguienteEstado);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"La solicitud ha avanzado a: {siguienteEstado}");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void DeshacerEstadoSolicitud(XelaTech xelaTech)
        {
            if (xelaTech.ListaTodasSolicitudes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No hay solicitudes registradas.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            int posicion = ValidarNumericoMenusGrandes(3, () => ListaDeSolicitudes(xelaTech), xelaTech.ListaTodasSolicitudes.Count);
            Solicitud solicitud = xelaTech.ListaTodasSolicitudes[posicion - 1];
            if (solicitud.EstadoActual == EstadoSolicitud.Cancelada || solicitud.EstadoActual == EstadoSolicitud.ListaParaEntregar || solicitud.EstadoActual == EstadoSolicitud.Entregada)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"No se puede deshacer una solicitud que está en estado {solicitud.EstadoActual}.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            if (solicitud.EstadoActual == EstadoSolicitud.EnEspera)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"No se puede deshacer el estado, ya que no hay ningún estado anterior a {solicitud.EstadoActual}.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            if (solicitud.HistorialEstados.Count <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No hay estados previos para deshacer (se encuentra en su estado inicial).");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            solicitud.DeshacerEstado();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Se ha deshecho el último estado. El estado actual es ahora {solicitud.EstadoActual}.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostrarInformacionDeSolicitud(XelaTech xelaTech)
        {
            if (xelaTech.ListaTodasSolicitudes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No hay solicitudes registradas.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            int posicion = ValidarNumericoMenusGrandes(3, () => ListaDeSolicitudes(xelaTech), xelaTech.ListaTodasSolicitudes.Count);
            Solicitud solicitud = xelaTech.ListaTodasSolicitudes[posicion - 1];
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("    INFORMACIÓN DE SOLICITUD      ");
            Console.WriteLine("==================================\n");
            Console.ResetColor();
            solicitud.MostrarDetalles();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- HISTORIAL DE ESTADOS ---");
            Console.ResetColor();
            solicitud.MostrarHistorialDeEstados();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- REPUESTOS USADOS ---");
            Console.ResetColor();
            solicitud.MostrarListaDeRespuestosUsados();
            LimpiarConsola();
        }

        public static void LimpiarConsola()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar\n");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }

        public static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Error: opción no válida\n");
            Console.ResetColor();
            LimpiarConsola();
        }
    }
}
