using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloReportes
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuReportes, 9);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1: 
                        ReporteSolicitudesEnEspera(xelaTech); 
                        break;
                    case 2: 
                        ReporteEstadosSolicitudes(xelaTech);
                        break;
                    case 3: 
                        ReporteTecnicosDisponiblesYCompletos(xelaTech); 
                        break;
                    case 4: 
                        ReporteTecnicoMasServicios(xelaTech); 
                        break;
                    case 5: 
                        ReporteEquiposAtendidosPorTipo(xelaTech); 
                        break;
                    case 6:
                        ReporteRepuestosCriticos(xelaTech); 
                        break;
                    case 7: 
                        ReporteIngresosTotales(xelaTech);
                        break;
                    case 8:
                        ReporteMatrizCargaTrabajo(xelaTech);
                        break;
                    case 9: 

                        break;
                    default: 
                        Error(); 
                        break;
                }
            } while (opcionMenu != 9);
        }

        public static void OpcionesMenuReportes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         MÓDULO DE REPORTES        ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Solicitudes en espera por prioridad");
            Console.WriteLine("2. Solicitudes activas, finalizadas y canceladas");
            Console.WriteLine("3. Técnicos disponibles y con carga completa");
            Console.WriteLine("4. Técnico con más servicios finalizados");
            Console.WriteLine("5. Equipos atendidos por tipo");
            Console.WriteLine("6. Repuestos con existencia mínima o agotados");
            Console.WriteLine("7. Ingresos totales por servicios finalizados");
            Console.WriteLine("8. Matriz semanal de carga de trabajo");
            Console.WriteLine("9. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void ReporteSolicitudesEnEspera(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" SOLICITUDES EN ESPERA POR PRIORIDAD");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- PRIORIDAD URGENTE ---");
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes.Where(solicitud => solicitud.Prioridad == PrioridadSolicitud.Urgente && (solicitud.EstadoActual == EstadoSolicitud.Recibida || solicitud.EstadoActual == EstadoSolicitud.EnEspera)))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {solicitud.Codigo} | {ColorConsola.Verde}Cliente:{ColorConsola.Reset} {solicitud.Cliente.NombreCompleto} | {ColorConsola.Azul}Equipo:{ColorConsola.Reset} {solicitud.Equipo.ObtenerTipoDeEquipo()}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- PRIORIDAD NORMAL ---");
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes.Where(solicitud => solicitud.Prioridad == PrioridadSolicitud.Normal && (solicitud.EstadoActual == EstadoSolicitud.Recibida || solicitud.EstadoActual == EstadoSolicitud.EnEspera)))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {solicitud.Codigo} | {ColorConsola.Verde}Cliente:{ColorConsola.Reset} {solicitud.Cliente.NombreCompleto} | {ColorConsola.Azul}Equipo:{ColorConsola.Reset} {solicitud.Equipo.ObtenerTipoDeEquipo()}");
            }
            LimpiarConsola();
        }

        public static void ReporteEstadosSolicitudes(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" ESTADOS GENERALES DE SOLICITUDES  ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- SOLICITUDES ACTIVAS (Asignadas, En Diagnóstico, En Reparación, Listas) ---");
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes.Where(solicitud => solicitud.EstadoActual == EstadoSolicitud.Asignado || solicitud.EstadoActual == EstadoSolicitud.EnDiagnostico || solicitud.EstadoActual == EstadoSolicitud.EnReparacion || solicitud.EstadoActual == EstadoSolicitud.ListaParaEntregar))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {solicitud.Codigo} | {ColorConsola.Verde}Estado:{ColorConsola.Reset} {solicitud.ObtenerEstadoSolicitud()}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- SOLICITUDES FINALIZADAS (Entregadas) ---");
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes.Where(solicitud => solicitud.EstadoActual == EstadoSolicitud.Entregada))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {solicitud.Codigo} | {ColorConsola.Verde}Cliente:{ColorConsola.Reset} {solicitud.Cliente.NombreCompleto}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- SOLICITUDES CANCELADAS ---");
            Console.ResetColor();
            foreach (Solicitud solicitud in xelaTech.ListaTodasSolicitudes.Where(solicitud => solicitud.EstadoActual == EstadoSolicitud.Cancelada))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {solicitud.Codigo} | {ColorConsola.Verde}Cliente:{ColorConsola.Reset} {solicitud.Cliente.NombreCompleto}");
            }
            LimpiarConsola();
        }

        public static void ReporteTecnicosDisponiblesYCompletos(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" DISPONIBILIDAD DE TÉCNICOS        ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- TÉCNICOS DISPONIBLES ---");
            Console.ResetColor();
            foreach (Tecnico tecnico in xelaTech.ListaTecnicos.Where(tecnico => tecnico.Estado == EstadoTecnico.Disponible))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {tecnico.Codigo} | {ColorConsola.Verde}Nombre:{ColorConsola.Reset} {tecnico.NombreCompleto} | {ColorConsola.Azul}Trabajos Actuales:{ColorConsola.Reset} {tecnico.TrabajosActivos}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- TÉCNICOS CON CARGA COMPLETA (OCUPADOS) O INACTIVOS ---");
            Console.ResetColor();
            foreach (Tecnico tecnico in xelaTech.ListaTecnicos.Where(tecnico => tecnico.Estado == EstadoTecnico.Inactivo || tecnico.TrabajosActivos >= 3))
            {
                Console.WriteLine($"{ColorConsola.Reset}ID:{ColorConsola.Reset} {tecnico.Codigo} | {ColorConsola.Verde}Nombre:{ColorConsola.Reset} {tecnico.NombreCompleto} | {ColorConsola.Azul}Estado Actual:{ColorConsola.Reset} {tecnico.Estado}");
            }
            LimpiarConsola();
        }

        public static void ReporteTecnicoMasServicios(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" TÉCNICO CON MÁS SERVICIOS         ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            if (xelaTech.ListaTecnicos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay técnicos registrados en el sistema.");
                Console.ResetColor();
            }
            else
            {
                Tecnico tecnicoTop = xelaTech.ListaTecnicos[0];
                foreach (Tecnico tecnico in xelaTech.ListaTecnicos)
                {
                    if (tecnico.ServiciosFinalizados > tecnicoTop.ServiciosFinalizados)
                    {
                        tecnicoTop = tecnico;
                    }
                }
                if (tecnicoTop.ServiciosFinalizados == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Todos los técnicos tienen 0 servicios realizados ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Técnico Destacado: ");
                    Console.ResetColor();
                    Console.WriteLine($"{tecnicoTop.NombreCompleto} (ID: {tecnicoTop.Codigo})");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Total de Servicios Finalizados: ");
                    Console.ResetColor();
                    Console.WriteLine(tecnicoTop.ServiciosFinalizados);
                }
            }
            LimpiarConsola();
        }

        public static void ReporteEquiposAtendidosPorTipo(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" EQUIPOS ATENDIDOS POR TIPO        ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            int laptops = xelaTech.ListaTodasSolicitudes.Count(solicitud => solicitud.Equipo.TipoEquipo == TipoEquipo.Laptop);
            int pcEscritorio = xelaTech.ListaTodasSolicitudes.Count(solicitud => solicitud.Equipo.TipoEquipo == TipoEquipo.PCEscritorio);
            int impresoras = xelaTech.ListaTodasSolicitudes.Count(solicitud => solicitud.Equipo.TipoEquipo == TipoEquipo.Impresora);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Laptops: ");
            Console.ResetColor();
            Console.WriteLine(laptops);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("PC de Escritorio: ");
            Console.ResetColor();
            Console.WriteLine(pcEscritorio);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Impresoras: ");
            Console.ResetColor();
            Console.WriteLine(impresoras);
            LimpiarConsola();
        }

        public static void ReporteRepuestosCriticos(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" REPUESTOS CRÍTICOS O AGOTADOS     ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- REPUESTOS AGOTADOS ---");
            Console.ResetColor();
            foreach (Repuesto repuesto in xelaTech.ListaRepuestos.Where(repuesto => repuesto.Existencia == 0))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {repuesto.Codigo} | {ColorConsola.Verde}Nombre:{ColorConsola.Reset} {repuesto.Nombre} | {ColorConsola.Azul}Mínimo Requerido:{ColorConsola.Reset} {repuesto.ExistenciaMinima}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("--- REPUESTOS EN EXISTENCIA MÍNIMA (O MENOS) ---");
            Console.ResetColor();
            foreach (Repuesto repuesto in xelaTech.ListaRepuestos.Where(repuesto => repuesto.Existencia > 0 && repuesto.Existencia <= repuesto.ExistenciaMinima))
            {
                Console.WriteLine($"{ColorConsola.Rojo}ID:{ColorConsola.Reset} {repuesto.Codigo} | {ColorConsola.Verde}Nombre:{ColorConsola.Reset} {repuesto.Nombre} | {ColorConsola.Azul}Existencia Actual:{ColorConsola.Reset} {repuesto.Existencia} | Mínimo Requerido: {repuesto.ExistenciaMinima}");
            }
            LimpiarConsola();
        }

        public static void ReporteIngresosTotales(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" INGRESOS TOTALES DEL SISTEMA      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Total Acumulado por Servicios Finalizados: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Q. {xelaTech.IngresosTotales:F2}");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ReporteMatrizCargaTrabajo(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine(" MATRIZ SEMANAL DE CARGA DE TRABAJO");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            if (xelaTech.ListaTecnicos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay técnicos registrados para mostrar la matriz.");
                Console.ResetColor();
            }
            else
            {
                string[] dias = { "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" };
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Técnico         ");
                foreach (string dia in dias)
                {
                    Console.Write($"{dia}  ");
                }
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < xelaTech.ListaTecnicos.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string nombreCorto = xelaTech.ListaTecnicos[i].NombreCompleto;
                    if (nombreCorto.Length > 15)
                    {
                        nombreCorto = nombreCorto.Substring(0, 15);
                    }
                    Console.Write(nombreCorto.PadRight(16));
                    Console.ResetColor();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write($"{xelaTech.CargaSemanal[i, j].ToString().PadRight(5)}");
                    }
                    Console.WriteLine();
                }
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
