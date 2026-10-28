using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum EspecialidadTecnico { Laptop = 1, PCEscritorio = 2, Impresoras = 3 }

    public enum EstadoTecnico { Disponible = 1, Ocupado = 2, Inactivo = 3 }

    public class Tecnico
    {
        private string codigo;

        private string prefijo = "TEC";

        private string nombreCompleto;

        private EspecialidadTecnico especialidad;

        private EstadoTecnico estado;

        private int trabajosActivos;

        private int serviciosFinalizados;

        private double calificacionPromedio;

        public Tecnico(string nombre, EspecialidadTecnico especialidad, EstadoTecnico estado)
        {
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
            Console.Write(ObtenerEspecialidadTecnico());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Estado: ");
            Console.ResetColor();
            Console.Write(ObtenerEstadoTecnico());
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

        public string ObtenerEspecialidadTecnico()
        {
            switch (Especialidad)
            {
                case EspecialidadTecnico.Impresoras: return "Impresoras";
                case EspecialidadTecnico.Laptop: return "Laptop";
                case EspecialidadTecnico.PCEscritorio: return "PC de escritorio";
                default: return Especialidad.ToString();
            }
        }

        public string ObtenerEstadoTecnico()
        {
            switch (Estado)
            {
                case EstadoTecnico.Disponible: return "Disponible";
                case EstadoTecnico.Inactivo: return "No disponible";
                case EstadoTecnico.Ocupado: return "Ocupado";
                default: return Estado.ToString();
            }
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

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
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
