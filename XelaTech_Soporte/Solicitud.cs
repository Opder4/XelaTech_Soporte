using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum PrioridadSolicitud { Normal = 1, Urgente = 2 };
    public enum EstadoSolicitud { Recibida = 1, EnEspera = 2, Asignado = 3, EnDiagnostico = 4, EnReparacion = 5, ListaParaEntregar = 6, Entregada = 7, Cancelada = 8 };

    public class Solicitud
    {
        private string codigo;

        private string prefijo;

        private Cliente cliente;

        private Equipo equipo;

        private string descripcionProblema;

        private DateTime fechaRecepcion;

        private PrioridadSolicitud prioridad;

        private EstadoSolicitud estadoActual;

        private Stack<EstadoSolicitud> historialEstados;

        private Tecnico tecnicoAsigando;

        private string diagnostico;

        private List<Repuesto> repuestosUsados;

        private double manoDeObra;

        public Solicitud(string codigo, Cliente cliente, Equipo equipo, string descripcionProblema, PrioridadSolicitud prioridad)
        {
            Codigo = codigo;
            Cliente = cliente;
            Equipo = equipo;
            DescripcionProblema = descripcionProblema;
            FechaRecepcion = DateTime.Now;
            Prioridad = prioridad;
            EstadoActual = EstadoSolicitud.Recibida;
            HistorialEstados = new Stack<EstadoSolicitud>();
            HistorialEstados.Push(EstadoActual);
            RepuestosUsados = new List<Repuesto>();
            ManoDeObra = 0;
        }

        public void MostrarDetalles()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ID: ");
            Console.ResetColor();
            Console.Write(Codigo);
            Console.WriteLine();
            Console.Write("Cliente: ");
            Console.ResetColor();
            Console.Write(Cliente.NombreCompleto + $" | {Cliente.Telefono} | {Cliente.Codigo}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Equipo: ");
            Console.ResetColor();
            Console.Write(Equipo.NumeroSerie + $" | {Equipo.Marca} | {Equipo.Modelo} | {Equipo.Codigo}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Descrición del Problema: ");
            Console.ResetColor();
            Console.Write(DescripcionProblema);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Fecha de Recepción: ");
            Console.ResetColor();
            Console.Write(FechaRecepcion);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Prioridad: ");
            Console.ResetColor();
            Console.Write(Prioridad);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Estado de la Solicitud: ");
            Console.ResetColor();
            Console.Write(EstadoActual);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Técnico Asinado: ");
            Console.ResetColor();
            if (TecnicoAsignado == null)
            {
                Console.Write("Sin técnico asignado");
            }
            else
            {
                Console.Write(TecnicoAsignado.NombreCompleto + $" | {TecnicoAsignado.Codigo}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Diagnóstico: ");
            Console.ResetColor();
            if (Diagnostico == null)
            {
                Console.Write("Sin diagnóstico");
            }
            else
            {
                Console.Write(Diagnostico);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Costo de mano de obra: ");
            Console.ResetColor();
            if (ManoDeObra == 0)
            {
                Console.Write("Aún no se ha completado el servicio");
            }
            else
            {
                Console.Write("Q. " + ManoDeObra);
            }
        }

        public void MostrarHistorialDeEstados()
        {
            if (HistorialEstados.Count > 0)
            {
                int numeracion = 1;
                foreach (EstadoSolicitud estado in HistorialEstados)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{numeracion}°: ");
                    Console.ResetColor();
                    Console.Write(estado);
                    numeracion++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningún estado registrado");
                Console.ResetColor();
            }
        }

        public void MostrarListaDeRespuestosUsados()
        {
            if (RepuestosUsados.Count > 0)
            {
                foreach (Repuesto repuesto in RepuestosUsados)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("- ");
                    Console.ResetColor();
                    Console.Write(repuesto.Nombre + $" | {repuesto.Categoria} | {repuesto.Codigo}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay repuestos usados");
                Console.ResetColor();
            }
        }

        public void ActualizarEstado(EstadoSolicitud nuevoEstado)
        {
            // Por definir
        }

        public void DeshacerEstado()
        {
            // Por definir
        }

        public double CalcularTotal()
        {
            return 0; // Por definir función
        }

        public double ManoDeObra
        {
            get { return manoDeObra; }
            set { manoDeObra = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = "SOL"; }
        }

        public List<Repuesto> RepuestosUsados
        {
            get { return repuestosUsados; }
            set { repuestosUsados = value; }
        }

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public Tecnico TecnicoAsignado
        {
            get { return tecnicoAsigando; }
            set { tecnicoAsigando = value; }
        }

        public Stack<EstadoSolicitud> HistorialEstados
        {
            get { return historialEstados; }
            set { historialEstados = value; }
        }

        public EstadoSolicitud EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }

        public PrioridadSolicitud Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public DateTime FechaRecepcion
        {
            get { return fechaRecepcion; }
            set { fechaRecepcion = value; }
        }

        public string DescripcionProblema
        {
            get { return descripcionProblema; }
            set { descripcionProblema = value; }
        }

        public Equipo Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
    }
}
