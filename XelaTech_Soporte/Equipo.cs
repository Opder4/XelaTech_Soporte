using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public enum TipoEquipo { Laptop = 1, PCEscritorio = 2, Impresora = 3 };

    internal class Equipo
    {
		private string codigo;

		private string numeroSerie;

		private string marca;

		private string modelo;

		private Cliente propietario;

		private TipoEquipo tipoEquipo;

		private string estadoFisico;

		private string accesorios;

		public Equipo(string codigo, string numeroSerie, string marca, string modelo, Cliente propietario, TipoEquipo tipoEquipo, string estadoFisico, string accesorios)
		{
			Codigo = codigo;
			NumeroSerie = numeroSerie;
			Marca = marca;
			Modelo = modelo;
			Propietario = propietario;
			TipoEquipo = tipoEquipo;
			EstadoFisico = estadoFisico;
			Accesorios = accesorios;
		}

		public void MostrarDetalles()
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
            Console.Write(Propietario.NombreCompleto);
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

		public virtual void CalcularCostoRevision()
		{
           // Por definir en las clases hijas
		}

		public string Accesorios
		{
			get { return accesorios; }
			set { accesorios = value; }
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
}
