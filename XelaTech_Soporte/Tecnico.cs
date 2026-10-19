using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum EspecialidadTecnico { Laptop = 1, PCEscritorio = 2, Impresoras = 3 }

    public enum EstadoTecnico { Disponible = 1, Ocupado = 2, Inactivo = 3 }

    internal class Tecnico
    {
        private string codigo;

        private string nombreCompleto;

        private EspecialidadTecnico especialidad;

        private EstadoTecnico estado;

        private int trabajosActivos;

        private int serviciosFinalizados;

        private double calificacionPromedio;

        public Tecnico(string codigo, string nombre, EspecialidadTecnico especialidad, EstadoTecnico estado)
        {
            Codigo = codigo;
            NombreCompleto = nombre;
            Especialidad = especialidad;
            Estado = estado;
            TrabajosActivos = 0;
            ServiciosFinalizados = 0;
            CalificacionPromedio = 0;
        }

        public void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ID: ");
            Console.ResetColor();
            Console.Write(Codigo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Nombre: ");
            Console.ResetColor();
            Console.Write(NombreCompleto);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Especialidad: ");
            Console.ResetColor();
            Console.Write(Especialidad);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Estado: ");
            Console.ResetColor();
            Console.Write(Estado);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Trabajos Activos: ");
            Console.ResetColor();
            Console.Write(TrabajosActivos);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Servicios Finalizados: ");
            Console.ResetColor();
            Console.Write(ServiciosFinalizados);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Calificación Promedio: ");
            Console.ResetColor();
            Console.Write(CalificacionPromedio);
        }

        public void AsignarTrabajo()
        {
            // Por confirmar entrada y proceso
        }

        public void FinalizarTrabajo()
        {
            // Por confirmar entrada y proceso
        }

        public void ActualizarCalificacion()
        {
            // Por confirmar entrada y proceso
        }

        public double CalificacionPromedio
        {
            get { return calificacionPromedio; }
            set { calificacionPromedio = value; }
        }

        public int ServiciosFinalizados
        {
            get { return serviciosFinalizados; }
            set { serviciosFinalizados = value; }
        }

        public int TrabajosActivos
        {
            get { return trabajosActivos; }
            set { trabajosActivos = value; }
        }

        public EstadoTecnico Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public EspecialidadTecnico Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
