using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XelaTech_Soporte.AyudanteConsola;
namespace XelaTech_Soporte
{
    public static class ModuloGenerarDatosDePrueba
    {
        private static readonly Random random = new Random();

        public static void IniciarModulo(XelaTech xelaTech)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("    GENERANDO DATOS DE PRUEBA      ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
            GenerarClientes(xelaTech);
            GenerarTecnicos(xelaTech);
            GenerarEquipos(xelaTech);
            GenerarRepuestos(xelaTech);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Se han Generado datos aleatorios en el sistema para su uso.");
            Console.ResetColor();
            LimpiarConsola();
        }

        private static void GenerarClientes(XelaTech xelaTech)
        {
            string[] nombres = { "Juan", "María", "Carlos", "Ana", "Luis", "Elena", "Pedro", "Lucía", "Diego", "Carmen", "Javier", "Sofía" };
            string[] apellidos = { "Pérez", "López", "Gómez", "Ramírez", "Fernández", "Díaz", "Martínez", "García", "Rodríguez", "Hernández", "Cruz", "Morales" };
            string[] dominios = { "correo.com", "uni.edu", "empresa.net", "negocio.com", "institucion.org" };
            int cantidadClientes = random.Next(8, 16);
            for (int i = 0; i < cantidadClientes; i++)
            {
                string nombreCompleto = nombres[random.Next(nombres.Length)] + " " + apellidos[random.Next(apellidos.Length)];
                int telefono = random.Next(10000000, 99999999);
                string correo = nombreCompleto.Replace(" ", "").ToLower() + "@" + dominios[random.Next(dominios.Length)];
                TipoCliente tipo = (TipoCliente)random.Next(1, 5);
                xelaTech.IngresarCliente(new Cliente(nombreCompleto, telefono, correo, tipo));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> {cantidadClientes} Clientes generados aleatoriamente.");
            Console.ResetColor();
        }

        private static void GenerarTecnicos(XelaTech xelaTech)
        {
            string[] nombresTec = { "Roberto", "Silvia", "Mario", "Teresa", "Jorge", "Raquel", "Miguel", "Laura", "Fernando", "Diana" };
            string[] apellidosTec = { "Sánchez", "Reyes", "Vargas", "Mendoza", "Torres", "Ruiz", "Castillo", "Ortiz", "Navarro", "Ramos" };
            int cantidadTecnicos = random.Next(5, 11);
            for (int i = 0; i < cantidadTecnicos; i++)
            {
                string nombreCompleto = nombresTec[random.Next(nombresTec.Length)] + " " + apellidosTec[random.Next(apellidosTec.Length)];
                EspecialidadTecnico especialidad = (EspecialidadTecnico)random.Next(1, 4);
                EstadoTecnico estado = (EstadoTecnico)random.Next(1, 4);
                xelaTech.IngresarTecnico(new Tecnico(nombreCompleto, especialidad, estado));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> {cantidadTecnicos} Técnicos generados aleatoriamente.");
            Console.ResetColor();
        }

        private static void GenerarEquipos(XelaTech xelaTech)
        {
            string[] marcasLaptop = { "Dell", "HP", "Lenovo", "Asus", "Acer", "MSI", "Apple" };
            string[] modelosLaptop = { "Inspiron", "Pavilion", "ThinkPad", "ZenBook", "Aspire", "Katana", "MacBook Air" };
            string[] marcasPC = { "Lenovo", "Dell", "HP", "Corsair", "Alienware", "Clon Genérico" };
            string[] modelosPC = { "ThinkCentre", "OptiPlex", "ProDesk", "Vengeance", "Aurora", "Armada Custom" };
            string[] marcasImp = { "Epson", "HP", "Canon", "Brother", "Lexmark" };
            string[] modelosImp = { "EcoTank", "LaserJet", "Pixma", "HL-Series", "MB-Series" };
            string[] problemas = { "Pantalla rota", "No enciende", "Lento", "Manchas de tinta", "Polvo interno", "Sobrecalentamiento", "Teclado falla", "Atasco de papel" };
            int cantidadEquipos = random.Next(10, 21);
            for (int i = 0; i < cantidadEquipos; i++)
            {
                Cliente propietario = xelaTech.ListaClientes[random.Next(xelaTech.ListaClientes.Count)];
                TipoEquipo tipo = (TipoEquipo)random.Next(1, 4);
                string serie = "SN-" + random.Next(10000, 99999);
                string estadoFisico = problemas[random.Next(problemas.Length)];
                if (tipo == TipoEquipo.Laptop)
                {
                    bool incluyeCargador = random.Next(2) == 0;
                    xelaTech.IngresarEquipo(new Laptop(serie, marcasLaptop[random.Next(marcasLaptop.Length)], modelosLaptop[random.Next(modelosLaptop.Length)], propietario, tipo, estadoFisico, "Funda protectora", incluyeCargador));
                }
                else if (tipo == TipoEquipo.PCEscritorio)
                {
                    xelaTech.IngresarEquipo(new ComputadoraEscritorio(serie, marcasPC[random.Next(marcasPC.Length)], modelosPC[random.Next(modelosPC.Length)], propietario, tipo, estadoFisico, "Teclado y Mouse", "ATX Torre"));
                }
                else if (tipo == TipoEquipo.Impresora)
                {
                    xelaTech.IngresarEquipo(new Impresora(serie, marcasImp[random.Next(marcasImp.Length)], modelosImp[random.Next(modelosImp.Length)], propietario, tipo, estadoFisico, "Cable de poder y USB", "Inyección de Tinta"));
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> {cantidadEquipos} Equipos generados y asignados aleatoriamente.");
            Console.ResetColor();
        }

        private static void GenerarRepuestos(XelaTech xelaTech)
        {
            string[] componentes = { "Disco Duro HDD", "SSD NVMe", "Memoria RAM", "Pantalla LED", "Teclado", "Batería", "Cabezal de Impresión", "Fuente de Poder", "Ventilador", "Placa Base", "Tinta Negra" };
            string[] categorias = { "Almacenamiento", "Almacenamiento", "Memoria", "Pantalla", "Periférico", "Energía", "Componente", "Energía", "Refrigeración", "Componente", "Consumible" };
            int cantidadRepuestos = random.Next(10, 20);
            for (int i = 0; i < cantidadRepuestos; i++)
            {
                int indice = random.Next(componentes.Length);
                string nombre = componentes[indice] + " Variante " + random.Next(1, 100);
                string categoria = categorias[indice];
                int existencia = random.Next(5, 50);
                int minima = random.Next(1, 5);
                double costo = random.Next(25, 800) + random.NextDouble();
                xelaTech.IngresarRepuesto(new Repuesto(nombre, categoria, existencia, minima, costo));
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> {cantidadRepuestos} Repuestos generados aleatoriamente.");
            Console.ResetColor();
        }

        public static void LimpiarConsola()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }
    }
}
