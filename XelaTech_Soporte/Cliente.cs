using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum TipoCliente { Estudiante = 1, PersonaComun = 2, negocioPequeno = 3, Institucion = 4 };

    public class Cliente
    {
        private string codigo;

        private string prefijo = "CLI";

        private string nombreCompleto;

        private int telefono;

        private string correo;

        private TipoCliente tipoCliente;

        private int solicitudesRegistradas;

        public Cliente(string nombre, int telefono, string correo, TipoCliente tipoCliente)
        {
            NombreCompleto = nombre;
            Telefono = telefono;
            Correo = correo;
            TipoCCliente = tipoCliente;
            solicitudesRegistradas = 0;
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
            Console.Write("Número de Teléfono: ");
            Console.ResetColor();
            Console.Write(Telefono);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Correo Electrónico: ");
            Console.ResetColor();
            Console.Write(Correo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Tipo de Cliente: ");
            Console.ResetColor();
            Console.Write(ObtenerTipoCliente());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Solicitudes Realizadas: ");
            Console.ResetColor();
            Console.Write(SolicitudesRegistradas);
        }

        public string ObtenerTipoCliente()
        {
            switch (TipoCCliente)
            {
                case TipoCliente.Estudiante:
                    return "Estudiante";
                case TipoCliente.PersonaComun:
                    return "Persona Común";
                case TipoCliente.negocioPequeno:
                    return "Pequeño Negocio";
                case TipoCliente.Institucion:
                    return "Institución";
                default:
                    return TipoCCliente.ToString();
            }
        }

        public int SolicitudesRegistradas
        {
            get { return solicitudesRegistradas; }
            set { solicitudesRegistradas = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
        }

        public TipoCliente TipoCCliente
        {
            get { return tipoCliente; }
            set { tipoCliente = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
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
