using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;

namespace XelaTech_Soporte
{
    public static class ModuloAtencionDeSolicitudes
    {
        public static void IniciarModulo(XelaTech xelaTech)
        {
            int opcionMenu = 0;
            do
            {
                opcionMenu = ValidarNumerico(1, OpcionesMenuAtencion, 2);
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1: 
                        AtenderSiguienteSolicitud(xelaTech); 
                        break;
                    case 2: 

                        break;
                    default: 
                        Error(); 
                        break;
                }
            } while (opcionMenu != 2);
        }

        public static void OpcionesMenuAtencion()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("      ATENCIÓN DE SOLICITUDES      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Atender Siguiente Solicitud");
            Console.WriteLine("2. Regresar al Menú Principal");
            Console.ResetColor();
        }

        public static void AtenderSiguienteSolicitud(XelaTech xelaTech)
        {
            bool esUrgente = false;
            Solicitud solicitudPendiente = null;
            if (xelaTech.ColaUrgente.Count > 0)
            {
                solicitudPendiente = xelaTech.ColaUrgente.Peek();
                esUrgente = true;
            }
            else if (xelaTech.ColaNormal.Count > 0)
            {
                solicitudPendiente = xelaTech.ColaNormal.Peek();
            }
            if (solicitudPendiente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No hay solicitudes pendientes en las colas.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            EspecialidadTecnico especialidadRequerida = EspecialidadTecnico.Laptop;
            if (solicitudPendiente.Equipo.TipoEquipo == TipoEquipo.PCEscritorio)
            {
                especialidadRequerida = EspecialidadTecnico.PCEscritorio;
            }
            else if (solicitudPendiente.Equipo.TipoEquipo == TipoEquipo.Impresora)
            {
                especialidadRequerida = EspecialidadTecnico.Impresoras;
            }
            Tecnico tecnicoDisponible = null;
            foreach (Tecnico tecnico in xelaTech.ListaTecnicos)
            {
                if (tecnico.Estado == EstadoTecnico.Disponible && tecnico.Especialidad == especialidadRequerida)
                {
                    tecnicoDisponible = tecnico;
                    break;
                }
            }
            if (tecnicoDisponible == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"No hay técnicos DISPONIBLES con la especialidad ({especialidadRequerida}) para la solicitud {solicitudPendiente.Codigo}.");
                Console.WriteLine("La solicitud permanecerá como primera en la cola hasta que un técnico se desocupe.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            if (esUrgente)
            {
                xelaTech.ColaUrgente.Dequeue();
            }
            else
            {
                xelaTech.ColaNormal.Dequeue();
            }
            solicitudPendiente.TecnicoAsignado = tecnicoDisponible;
            solicitudPendiente.ActualizarEstado(EstadoSolicitud.Asignado);
            tecnicoDisponible.TrabajosActivos++;
            if (tecnicoDisponible.TrabajosActivos < 3)
            {
                tecnicoDisponible.Estado = EstadoTecnico.Disponible;
            }
            else
            {
                tecnicoDisponible.Estado = EstadoTecnico.Ocupado;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"La solicitud {solicitudPendiente.Codigo} fue asignada al técnico {tecnicoDisponible.NombreCompleto}.");
            Console.WriteLine("El estado de la solicitud ha avanzado a ASIGNADO.");
            if (tecnicoDisponible.Estado == EstadoTecnico.Ocupado)
            {
                Console.WriteLine("El técnico a alcanzado el límite de 3 trabajos simultaneos");
                Console.WriteLine("Ahora estará Ocupado hasta que complete un trabajo");
            }
            Console.ResetColor();
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
