using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public class XelaTech
    {
		private List<Cliente> listaClientes;

		private List<Tecnico> listaTecnicos;

		private List<Equipo> listaEquipos;

		private Queue<Solicitud> colaNormal;

		private Queue<Solicitud> colaUrgente;

		private List<Repuesto> listaRepuestos;

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
			listaClientes.Add(nuevoCliente);
		}

		public void IngresarTecnico(Tecnico nuevoTecnico)
		{
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

		public void IngresarEquipo(Equipo nuevoEquipo)
		{
			listaEquipos.Add(nuevoEquipo);
		}

		public void IngresarSolicitud(Solicitud nuevaSolicitud)
		{
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
