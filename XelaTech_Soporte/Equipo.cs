using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum TipoEquipo { Laptop = 1, PCEscritorio = 2, Impresora = 3 };

    public class Equipo
    {
        private string codigo;

        private string prefijo = "EQP";

        private string numeroSerie;

        private string marca;

        private string modelo;

        private Cliente propietario;

        private TipoEquipo tipoEquipo;

        private string estadoFisico;

        private string accesorios;

        public Equipo(string numeroSerie, string marca, string modelo, Cliente propietario, TipoEquipo tipoEquipo, string estadoFisico, string accesorios)
        {
            NumeroSerie = numeroSerie;
            Marca = marca;
            Modelo = modelo;
            Propietario = propietario;
            TipoEquipo = tipoEquipo;
            EstadoFisico = estadoFisico;
            Accesorios = accesorios;
        }

        public virtual void MostrarDetalles()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ID: ");
            Console.ResetColor();
            Console.Write(Codigo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Número de Serie: ");
            Console.ResetColor();
            Console.Write(NumeroSerie);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Marca: ");
            Console.ResetColor();
            Console.Write(Marca);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Modelo: ");
            Console.ResetColor();
            Console.Write(Modelo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Propietario: ");
            Console.ResetColor();
            Console.Write(Propietario.NombreCompleto + $" | {Propietario.Telefono} | {Propietario.Codigo}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Tipo de Equipo: ");
            Console.ResetColor();
            Console.Write(TipoEquipo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Estado Físico: ");
            Console.ResetColor();
            Console.Write(EstadoFisico);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Accesorios: ");
            Console.ResetColor();
            Console.Write(Accesorios);
        }

        public virtual double CalcularCostoRevision()
        {
            return 0;
        }

        public string Accesorios
        {
            get { return accesorios; }
            set { accesorios = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
        }

        public string EstadoFisico
        {
            get { return estadoFisico; }
            set { estadoFisico = value; }
        }

        public TipoEquipo TipoEquipo
        {
            get { return tipoEquipo; }
            set { tipoEquipo = value; }
        }

        public Cliente Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string NumeroSerie
        {
            get { return numeroSerie; }
            set { numeroSerie = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
    }

    class Laptop : Equipo
    {
        private bool incluyeCargador;

        public Laptop(string numeroSerie, string marca, string modelo, Cliente propietario, TipoEquipo tipoEquipo, string estadoFisico, string accesorios, bool incluyeCargador) : base(numeroSerie, marca, modelo, propietario, tipoEquipo, estadoFisico, accesorios)
        {
            IncluyeCargador = incluyeCargador;
        }

        public override double CalcularCostoRevision()
        {
            return 150;
        }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("¿Incluye Cargador?: ");
            Console.ResetColor();
            if (IncluyeCargador == true)
            {
                Console.Write("Si");
            }
            else
            {
                Console.Write("No");
            }
        }

        public bool IncluyeCargador
        {
            get { return incluyeCargador; }
            set { incluyeCargador = value; }
        }

    }

    class ComputadoraEscritorio : Equipo
    {
        private string formatoGabinete;

        public ComputadoraEscritorio(string numeroSerie, string marca, string modelo, Cliente propietario, TipoEquipo tipoEquipo, string estadoFisico, string accesorios, string formatoGabinete) : base(numeroSerie, marca, modelo, propietario, tipoEquipo, estadoFisico, accesorios)
        {
            FormatoGabinete = formatoGabinete;
        }

        public override double CalcularCostoRevision()
        {
            return 200;
        }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Formato del Gabinete: ");
            Console.ResetColor();
            Console.Write(FormatoGabinete);
        }

        public string FormatoGabinete
        {
            get { return formatoGabinete; }
            set { formatoGabinete = value; }
        }

    }

    class Impresora : Equipo
    {
        private string tipoImpresion;

        public Impresora(string numeroSerie, string marca, string modelo, Cliente propietario, TipoEquipo tipoEquipo, string estadoFisico, string accesorios, string tipoImpresion) : base(numeroSerie, marca, modelo, propietario, tipoEquipo, estadoFisico, accesorios)
        {
            TipoImpresion = tipoImpresion;
        }

        public override double CalcularCostoRevision()
        {
            return 150;
        }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Tipo de Impresion: ");
            Console.ResetColor();
            Console.Write(TipoImpresion);
        }

        public string TipoImpresion
        {
            get { return tipoImpresion; }
            set { tipoImpresion = value; }
        }
    }
}
