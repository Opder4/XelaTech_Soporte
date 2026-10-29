using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.CodigoUnico;

namespace XelaTech_Soporte
{
    public class XelaTech
    {
		private List<Cliente> listaClientes = new List<Cliente>();

		private List<Tecnico> listaTecnicos = new List<Tecnico>();

		private List<Equipo> listaEquipos = new List<Equipo>();

		private Queue<Solicitud> colaNormal = new Queue<Solicitud>();

		private Queue<Solicitud> colaUrgente = new Queue<Solicitud>();

		private List<Repuesto> listaRepuestos = new List<Repuesto>();

		private int[,] matrizCargaSemanal;

		private int[] calificaciones;

		public XelaTech()
		{
			listaClientes = new List<Cliente>();
			listaTecnicos = new List<Tecnico>();
			listaEquipos = new List<Equipo>();
			colaNormal = new Queue<Solicitud>();
			colaUrgente = new Queue<Solicitud>();
			matrizCargaSemanal = new int[0, 6];
			calificaciones = new int[5];
		}

		public void IngresarCliente(Cliente nuevoCliente)
		{
			string codigoUnico = GenerarCodigoUnico(nuevoCliente.Prefijo);
			nuevoCliente.Codigo = codigoUnico;
			listaClientes.Add(nuevoCliente);
		}

		public void IngresarTecnico(Tecnico nuevoTecnico)
		{
            string codigoUnico = GenerarCodigoUnico(nuevoTecnico.Prefijo);
            nuevoTecnico.Codigo = codigoUnico;
            listaTecnicos.Add(nuevoTecnico);
			int filasActuales = matrizCargaSemanal.GetLength(0);
			int[,] nuevaMatrizCargaSemanal = new int[filasActuales, 6];
			for (int i = 0; i < filasActuales; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					nuevaMatrizCargaSemanal[i, j] = matrizCargaSemanal[i, j];
				}
			}
			matrizCargaSemanal = nuevaMatrizCargaSemanal;
		}

		public void IngresarEquipo(Laptop nuevoEquipo)
		{
            string codigoUnico = GenerarCodigoUnico(nuevoEquipo.Prefijo);
            nuevoEquipo.Codigo = codigoUnico;
            listaEquipos.Add(nuevoEquipo);
		}

        public void IngresarEquipo(ComputadoraEscritorio nuevoEquipo)
        {
            string codigoUnico = GenerarCodigoUnico(nuevoEquipo.Prefijo);
            nuevoEquipo.Codigo = codigoUnico;
            listaEquipos.Add(nuevoEquipo);
        }

        public void IngresarEquipo(Impresora nuevoEquipo)
        {
            string codigoUnico = GenerarCodigoUnico(nuevoEquipo.Prefijo);
            nuevoEquipo.Codigo = codigoUnico;
            listaEquipos.Add(nuevoEquipo);
        }

        public void IngresarSolicitud(Solicitud nuevaSolicitud)
		{
            string codigoUnico = GenerarCodigoUnico(nuevaSolicitud.Prefijo);
            nuevaSolicitud.Codigo = codigoUnico;
            if (nuevaSolicitud.Prioridad == PrioridadSolicitud.Urgente)
			{
				colaUrgente.Enqueue(nuevaSolicitud);
			}
			else
			{
				colaNormal.Enqueue(nuevaSolicitud);
			}
		}

		public void IngresarRepuesto(Repuesto nuevoRepuesto)
		{
            string codigoUnico = GenerarCodigoUnico(nuevoRepuesto.Prefijo);
            nuevoRepuesto.Codigo = codigoUnico;
            listaRepuestos.Add(nuevoRepuesto);
		}

		public int[] Calificaciones
		{
			get { return calificaciones; }
			set { calificaciones = value; }
		}

		public int[,] CargaSemanal
		{
			get { return matrizCargaSemanal; }
			set { matrizCargaSemanal = value; }
		}

		public List<Repuesto> ListaRepuestos
		{
			get { return listaRepuestos; }
			set { listaRepuestos = value; }
		}

		public Queue<Solicitud> ColaUrgente
		{
			get { return colaUrgente; }
			set { colaUrgente = value; }
		}

		public Queue<Solicitud> ColaNormal
		{
			get { return colaNormal; }
			set { colaNormal = value; }
		}

		public List<Equipo> ListaEquipos
		{
			get { return listaEquipos; }
			set { listaEquipos = value; }
		}

		public List<Tecnico> ListaTecnicos
		{
			get { return listaTecnicos; }
			set { listaTecnicos = value; }
		}

		public List<Cliente> ListaClientes
		{
			get { return listaClientes; }
			set { listaClientes = value; }
		}
	}
}
