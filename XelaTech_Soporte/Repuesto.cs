using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    public class Repuesto
    {
        private string codigo;

        private string prefijo = "REP";

        private string nombre;

        private string categoria;

        private int existencia;

        private int existenciaMinima;

        private double costoUnitario;

        private double precioVenta;

        private int cantidadUtilizada;

        public Repuesto(string nombre, string categoria, int existencia, int existenciaMinima, double costoUnitario)
        {
            Nombre = nombre;
            Categoria = categoria;
            Existencia = existencia;
            ExistenciaMinima = existenciaMinima;
            CostoUnitario = costoUnitario;
            PrecioVenta = costoUnitario * 1.15;
            CantidadUtilizada = 0;
        }

        public int CantidadUtilizada
        {
            get { return cantidadUtilizada; }
            set { cantidadUtilizada = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
        }

        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public double CostoUnitario
        {
            get { return costoUnitario; }
            set { costoUnitario = value; }
        }

        public int ExistenciaMinima
        {
            get { return existenciaMinima; }
            set { existenciaMinima = value; }
        }

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
    }
}
