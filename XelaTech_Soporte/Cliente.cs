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

        private string prefijo;

        private string nombreCompleto;

        private string telefono;

        private string correo;

        private TipoCliente tipoCliente;

        private int solicitudesRegistradas;

        public Cliente(string codigo, string nombre, string telefono, string correo, TipoCliente tipoCliente)
        {
            Codigo = codigo;
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
            Console.Write(TipoCCliente);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Solicitudes Realizadas: ");
            Console.ResetColor();
            Console.Write(SolicitudesRegistradas);
        }

        public int SolicitudesRegistradas
        {
            get { return solicitudesRegistradas; }
            set { solicitudesRegistradas = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = "CLI"; }
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

        public string Telefono
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
