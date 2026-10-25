using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XelaTech_Soporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XelaTech Sistema_XelaTech_Soporte = new XelaTech();
            int opcionMenu = 0;
            string entrada;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("====== MENÚ DE XELATECH SOPORTE ======");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Gestión de Técnicos");
                Console.WriteLine("3. Gestión de Equipos");
                Console.WriteLine("4. Gestión de Solicitudes");
                Console.WriteLine("5. Gestión de Repuestos");
                Console.WriteLine("6. Atención de Solicitudes");
                Console.WriteLine("7. Ordenamientos");
                Console.WriteLine("8. Búsquedas");
                Console.WriteLine("9. Reportes");
                Console.WriteLine("10. Generar Datos de Prueba");
                Console.WriteLine("11. Salir");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Opción: ");
                Console.ResetColor();
                entrada = Console.ReadLine();
                while (!int.TryParse(entrada, out opcionMenu) || opcionMenu < 1 || opcionMenu > 11)
                {
                    if (!int.TryParse(entrada, out opcionMenu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Error: dato no válido");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Error: opción no válida");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Intente de nuevo: ");
                    Console.ResetColor();
                    entrada = Console.ReadLine();
                }
                Console.Clear();
                switch (opcionMenu)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:
                        Salir();
                        break;
                    default:
                        Error();
                        break;
                }
            } while (opcionMenu != 11);

            void LimpiarConsola()
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

            void Salir()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Gracias por usar el programa");
                Console.WriteLine();
                Console.ResetColor();
            }

            void Error()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Error: opción no válida");
                Console.WriteLine();
                Console.ResetColor();
                LimpiarConsola();
            }
        }
    }
}
