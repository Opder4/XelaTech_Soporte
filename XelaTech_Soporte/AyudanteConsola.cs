using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XelaTech_Soporte;

namespace XelaTech_Soporte
{
    internal static class AyudanteConsola
    {
        public static string ObtenerDescripcion(this Enum valor)
        {
            FieldInfo field = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : valor.ToString();
        }

        public static string ObtenerTipoCliente(TipoCliente tipoCliente)
        {
            switch (tipoCliente)
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
                    return tipoCliente.ToString();
            }
        }

        public static int MenuTipoDeCliente()
        {
            string mensajeSolicitud = "Elija su Tipo de Cliente";
            int numeroElegido;
            List<string> listaTipos = Enum.GetValues(typeof(TipoCliente))
                                   .Cast<TipoCliente>()
                                   .Select(m => ObtenerTipoCliente(m))
                                   .ToList();
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitud.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitud.ToUpper());
            Console.ResetColor();
            Console.Write("\n\n");
            StringBuilder sbTipo = new StringBuilder(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el número correspondiente\n");
            Console.ResetColor();
            foreach (string tipo in listaTipos)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaTipos.IndexOf(tipo) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{tipo}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nElección: ");
            Console.ResetColor();

            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sbTipo.Length == 1)
                {
                    numeroElegido = int.Parse(sbTipo.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n\nConfirmar elección de ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listaTipos[numeroElegido - 1]);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" (Yes/No): ");
                    Console.ResetColor();
                    string respuesta = Console.ReadLine().ToLower().Trim();
                    if (respuesta == "no")
                    {
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuTipoDeCliente(); 
                    }
                    else if (respuesta == "yes")
                    {
                        Console.Clear();
                        break; 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nElección inválida");
                        Console.ResetColor();
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuTipoDeCliente();
                    }
                }
                if (teclaInfo.Key == ConsoleKey.Backspace && sbTipo.Length > 0)
                {
                    sbTipo.Remove(sbTipo.Length - 1, 1);
                    Console.Write("\b \b");
                }
                if (sbTipo.Length < 1)
                {
                    if (char.IsDigit(teclaInfo.KeyChar))
                    {
                        int numeroConvertido = int.Parse(teclaInfo.KeyChar.ToString());
                        if (numeroConvertido >= 1 && numeroConvertido <= listaTipos.Count)
                        {
                            sbTipo.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                    }
                }
            } while (true);

            return numeroElegido;
        }

        public static string ObtenerEspecialidadTecnico(EspecialidadTecnico especialidad)
        {
            switch (especialidad)
            {
                case EspecialidadTecnico.Impresoras: return "Impresoras";
                case EspecialidadTecnico.Laptop: return "Laptop";
                case EspecialidadTecnico.PCEscritorio: return "PC de escritorio";
                default: return especialidad.ToString();
            }
        }

        public static string ObtenerTipoDeEquipo(TipoEquipo tipoEquipo)
        {
            switch (tipoEquipo)
            {
                case TipoEquipo.Impresora: return "Impresora";
                case TipoEquipo.Laptop: return "Laptop";
                case TipoEquipo.PCEscritorio: return "PC de escritorio";
                default: return tipoEquipo.ToString();
            }
        }

        public static int MenuTipoDeEquipo()
        {
            string mensajeSolicitud = "Elija el Tipo de Equipo";
            int numeroElegido;
            List<string> listaTiposDeEquipo = Enum.GetValues(typeof(TipoEquipo))
                                   .Cast<TipoEquipo>()
                                   .Select(m => ObtenerTipoDeEquipo(m))
                                   .ToList();
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitud.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitud.ToUpper());
            Console.ResetColor();
            Console.Write("\n\n");
            StringBuilder sbEspecialidad = new StringBuilder(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el número correspondiente:\n");
            Console.ResetColor();
            for (int i = 0; i < listaTiposDeEquipo.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(listaTiposDeEquipo[i]);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nElección: ");
            Console.ResetColor();
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                if (teclaInfo.Key == ConsoleKey.Enter && sbEspecialidad.Length == 1)
                {
                    numeroElegido = int.Parse(sbEspecialidad.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\nConfirmar elección de ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listaTiposDeEquipo[numeroElegido - 1]);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" (Yes/No): ");
                    Console.ResetColor();
                    string respuesta = Console.ReadLine().ToLower().Trim();
                    if (respuesta == "no")
                    {
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEspecialidadTecnico();
                    }
                    else if (respuesta == "yes")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nElección inválida");
                        Console.ResetColor();
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEspecialidadTecnico();
                    }
                }
                if (teclaInfo.Key == ConsoleKey.Backspace && sbEspecialidad.Length > 0)
                {
                    sbEspecialidad.Remove(sbEspecialidad.Length - 1, 1);
                    Console.Write("\b \b");
                }
                if (sbEspecialidad.Length < 1 && char.IsDigit(teclaInfo.KeyChar))
                {
                    int numeroConvertido = int.Parse(teclaInfo.KeyChar.ToString());
                    if (numeroConvertido >= 1 && numeroConvertido <= listaTiposDeEquipo.Count)
                    {
                        sbEspecialidad.Append(teclaInfo.KeyChar);
                        Console.Write(teclaInfo.KeyChar);
                    }
                }
            } while (true);

            return numeroElegido;
        }

        public static int MenuEspecialidadTecnico()
        {
            string mensajeSolicitud = "Elija la Especialidad del Técnico";
            int numeroElegido;
            List<string> listaEspecialidades = Enum.GetValues(typeof(EspecialidadTecnico))
                                   .Cast<EspecialidadTecnico>()
                                   .Select(m => ObtenerEspecialidadTecnico(m))
                                   .ToList();
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitud.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitud.ToUpper());
            Console.ResetColor();
            Console.Write("\n\n");
            StringBuilder sbEspecialidad = new StringBuilder(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el número correspondiente:\n");
            Console.ResetColor();
            for (int i = 0; i < listaEspecialidades.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(listaEspecialidades[i]);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nElección: ");
            Console.ResetColor();
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sbEspecialidad.Length == 1)
                {
                    numeroElegido = int.Parse(sbEspecialidad.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\nConfirmar elección de ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listaEspecialidades[numeroElegido - 1]);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" (Yes/No): ");
                    Console.ResetColor();
                    string respuesta = Console.ReadLine().ToLower().Trim();
                    if (respuesta == "no")
                    {
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEspecialidadTecnico();
                    }
                    else if (respuesta == "yes")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nElección inválida");
                        Console.ResetColor();
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEspecialidadTecnico();
                    }
                }
                if (teclaInfo.Key == ConsoleKey.Backspace && sbEspecialidad.Length > 0)
                {
                    sbEspecialidad.Remove(sbEspecialidad.Length - 1, 1);
                    Console.Write("\b \b");
                }
                if (sbEspecialidad.Length < 1 && char.IsDigit(teclaInfo.KeyChar))
                {
                    int numeroConvertido = int.Parse(teclaInfo.KeyChar.ToString());
                    if (numeroConvertido >= 1 && numeroConvertido <= listaEspecialidades.Count)
                    {
                        sbEspecialidad.Append(teclaInfo.KeyChar);
                        Console.Write(teclaInfo.KeyChar);
                    }
                }
            } while (true);

            return numeroElegido;
        }

        public static string ObtenerEstadoTecnico(EstadoTecnico estado)
        {
            switch (estado)
            {
                case EstadoTecnico.Disponible: return "Disponible";
                case EstadoTecnico.Inactivo: return "No disponible";
                default: return estado.ToString();
            }
        }

        public static int MenuEstadoTecnico()
        {
            string mensajeSolicitud = "Elija el Estado del Técnico";
            int numeroElegido;
            List<EstadoTecnico> listaEstados = Enum.GetValues(typeof(EstadoTecnico))
                                   .Cast<EstadoTecnico>()
                                   .Where(m => m != EstadoTecnico.Ocupado)
                                   .ToList();
            List<string> listaNombres = listaEstados
                           .Select(m => ObtenerEstadoTecnico(m))
                           .ToList();
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitud.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitud.ToUpper());
            Console.ResetColor();
            Console.Write("\n\n");
            StringBuilder sbEstado = new StringBuilder(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el número correspondiente:\n");
            Console.ResetColor();
            for (int i = 0; i < listaNombres.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(listaEstados[i]);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nElección: ");
            Console.ResetColor();
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                if (teclaInfo.Key == ConsoleKey.Enter && sbEstado.Length == 1)
                {
                    numeroElegido = int.Parse(sbEstado.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\nConfirmar elección de ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listaEstados[numeroElegido - 1]);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" (Yes/No): ");
                    Console.ResetColor();
                    string respuesta = Console.ReadLine().ToLower().Trim();
                    if (respuesta == "no")
                    {
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEstadoTecnico();
                    }
                    else if (respuesta == "yes")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nElección inválida");
                        Console.ResetColor();
                        Mostrar("Reiniciando selección", 1);
                        Console.Clear();
                        return MenuEstadoTecnico();
                    }
                }
                if (teclaInfo.Key == ConsoleKey.Backspace && sbEstado.Length > 0)
                {
                    sbEstado.Remove(sbEstado.Length - 1, 1);
                    Console.Write("\b \b");
                }

                if (sbEstado.Length < 1 && char.IsDigit(teclaInfo.KeyChar))
                {
                    int numeroConvertido = int.Parse(teclaInfo.KeyChar.ToString());
                    if (numeroConvertido >= 1 && numeroConvertido <= listaEstados.Count)
                    {
                        sbEstado.Append(teclaInfo.KeyChar);
                        Console.Write(teclaInfo.KeyChar);
                    }
                }
            } while (true);

            return numeroElegido;
        }

        internal static string ValidarTexto(string mensajeSolicitudDeDatos, int limiteCaracteres)
        {
            bool textoConfirmado = false;
            string textoFinal = string.Empty;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!textoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar el texto ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sb.ToString());
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();
                        if (respuesta == "yes")
                        {
                            textoFinal = sb.ToString();
                            textoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsLetter(teclaInfo.KeyChar))
                        {
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        if (teclaInfo.Key == ConsoleKey.Spacebar && sb.Length > 0 && sb.Length + 1 != limiteCaracteres)
                        {
                            if (sb[sb.Length - 1] != ' ')
                            {
                                sb.Append(' ');
                                Console.Write(' ');
                            }
                        }
                    }
                } while (true);
            }
            return textoFinal;
        }

        internal static int ValidarNumerico(string mensajeSolicitudDeDatos, int tamanoRequerido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(tamanoRequerido);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" dígitos. \n\n Ingrsar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el número ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(numeroConvertido);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();
                            if (respuesta == "yes")
                            {
                                numeroFinal = numeroConvertido;
                                numeroConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarNumerico(string mensajeSolicitudDeDatos, int limiteCaracteres, bool esLimite)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;

            while (!numeroConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Presione Enter para enviar. \nEl número puede tener hasta ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(limiteCaracteres);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" dígitos. \n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el número ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(numeroConvertido);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();
                            if (respuesta == "yes")
                            {
                                numeroFinal = numeroConvertido;
                                numeroConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarNumerico(int tamanoRequerido, Action menuMostrar, int rangoValido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                menuMostrar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            if (numeroConvertido >= 1 && numeroConvertido <= rangoValido)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar el número ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(numeroConvertido);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();

                                if (respuesta == "yes")
                                {
                                    numeroFinal = numeroConvertido;
                                    numeroConfirmado = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nElección inválida");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarNumericoSinLimpiarConsola(int tamanoRequerido, Action menuMostrar, int rangoValido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            menuMostrar();
            while (!numeroConfirmado)
            {
                int posicionInicial = Console.CursorTop;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            if (numeroConvertido >= 1 && numeroConvertido <= rangoValido)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar el número ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(numeroConvertido);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();
                                if (respuesta == "yes")
                                {
                                    numeroFinal = numeroConvertido;
                                    numeroConfirmado = true;
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando número", 1);
                                    LimpiarDesde(posicionInicial);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nElección inválida");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    LimpiarDesde(posicionInicial);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static void LimpiarDesde(int filaInicio)
        {
            int filaActual = Console.CursorTop; 
            for (int i = filaInicio; i <= filaActual; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }
            Console.SetCursorPosition(0, filaInicio);
        }

        internal static int ValidarNumerico(int limiteCaracteres, Action menuMostrar, int rangoValido, bool esLimite)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                menuMostrar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            if (numeroConvertido >= 1 && numeroConvertido <= rangoValido)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar el número ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(numeroConvertido);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();
                                if (respuesta == "yes")
                                {
                                    numeroFinal = numeroConvertido;
                                    numeroConfirmado = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nElección inválida");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0' && sb.Length == 0)
                            {
                                continue;
                            }
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarNumerico<T>(int tamanoRequerido, Action<T> menuMostrar, T parametroMenu, int rangoValido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                menuMostrar(parametroMenu);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            if (numeroConvertido >= 1 && numeroConvertido <= rangoValido)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar el número ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(numeroConvertido);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();
                                if (respuesta == "yes")
                                {
                                    numeroFinal = numeroConvertido;
                                    numeroConfirmado = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nElección inválida");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarTelefono()
        {
            bool telefonoConfirmado = false;
            int telefonoFinal = 0;
            string mensajeSolicitudDeDatos = "Ingrese su número de teléfono";
            int tamanoRequerido = 8;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!telefonoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de 8 dígitos.\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el número de teléfono ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"{numeroConvertido.ToString("####-####")}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();
                            if (respuesta == "yes")
                            {
                                telefonoFinal = numeroConvertido;
                                telefonoConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando teléfono", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando teléfono", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        if (sb.Length == 4)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b\b \b");
                        }
                        else
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                    }

                    else if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0' && sb.Length == 0)
                            {
                                continue;
                            }

                            sb.Append(teclaInfo.KeyChar);

                            if (sb.Length == 4)
                            {
                                Console.Write(teclaInfo.KeyChar + "-");
                            }
                            else
                            {
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return telefonoFinal;
        }

        internal static string ValidarCorreo()
        {
            bool correoConfirmado = false;
            string mensajeSolicitudDeDatos = "Ingrese su correo";
            int limiteCaracteres = 35;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            string correoFinal = string.Empty;
            while (!correoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres && sb.ToString().Contains('@') && sb.ToString().Contains('.') && sb[sb.Length - 1] != '.' && sb[sb.Length - 1] != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar correo ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sb.ToString());
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();
                        if (respuesta == "yes")
                        {
                            correoFinal = sb.ToString();
                            correoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando correo", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando correo", 1);
                            break;
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        if (teclaInfo.KeyChar == '.')
                        {
                            if (sb.ToString().Contains('@') && sb[sb.Length - 1] != '.' && sb[sb.Length - 1] != '@' && sb.Length + 1 != limiteCaracteres)
                            {
                                sb.Append('.');
                                Console.Write('.');
                            }
                        }
                        if (teclaInfo.KeyChar == '@')
                        {
                            if (!sb.ToString().Contains('@') && sb.Length > 0 && sb.Length < 15)
                            {
                                sb.Append('@');
                                Console.Write('@');
                            }
                        }
                        if (!sb.ToString().Contains('@') && sb.Length == 15 && teclaInfo.Key != ConsoleKey.Backspace)
                        {
                            sb.Append('@');
                            Console.Write('@');
                        }
                    }
                } while (true);
            }
            return correoFinal;
        }
        internal static void Mostrar(string textoMostrar, int duracionSegundos)
        {
            int ciclosTotales = duracionSegundos * 4;
            for (int i = 0; i < ciclosTotales; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                int cantidadPuntos = i % 4;
                string puntos = new string('.', cantidadPuntos);
                string espaciosBlancos = new string(' ', 3 - cantidadPuntos);
                Console.Write($"\r{textoMostrar}{puntos}{espaciosBlancos}");
                Thread.Sleep(250);
            }
            Console.ResetColor();
            Console.Write("\r" + new string(' ', 20) + "\r");
        }
        
        internal static string ValidarAlfanumerico(string mensajePedirDatos, int limiteCaracteres)
        {
            bool alfanumericoConfirmado = false;
            string alfanumericoFinal = string.Empty;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajePedirDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!alfanumericoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajePedirDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar el texto ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sb.ToString());
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();
                        if (respuesta == "yes")
                        {
                            alfanumericoFinal = sb.ToString();
                            alfanumericoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres && teclaInfo.Key != ConsoleKey.Spacebar && teclaInfo.Key != ConsoleKey.Backspace)
                    {
                        sb.Append(teclaInfo.KeyChar);
                        Console.Write(teclaInfo.KeyChar);
                    }
                } while (true);
            }
            return alfanumericoFinal;
        }

        internal static double ValidarCalificacion()
        {
            string mensajeSolicitudDeDatos = "Ingrese su calificación";
            int tamanoRequerido = 2;
            bool calificacionConfirmada = false;
            double calificacionFinal = 0;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!calificacionConfirmada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\nCalificación de 1.0 a 5.0 \n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (double.TryParse(sb.ToString(), out double numeroConvertido))
                        {
                            double numeroDividido = numeroConvertido / 10.0;

                            if (numeroDividido >= 1.0 && numeroDividido <= 5.0 && numeroConvertido % 5 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar la calificación de ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($"{numeroDividido:F1}");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();

                                if (respuesta == "yes")
                                {
                                    calificacionFinal = numeroDividido;
                                    calificacionConfirmada = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando calificación", 1);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n Calificación inválida. Ingrese una calificación válida (ej. 2.5, 4.0)");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        if (sb.Length == 2)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        else if (sb.Length == 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b\b \b");
                        }
                    }
                    else if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0' && sb.Length == 0)
                            {
                                continue;
                            }

                            sb.Append(teclaInfo.KeyChar);

                            if (sb.Length == 1)
                            {
                                Console.Write(teclaInfo.KeyChar + ".");
                            }
                            else if (sb.Length == 2)
                            {
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return calificacionFinal;
        }

        internal static double ValidarPrecio(string mensajeSolicitudDeDatos, int limiteCaracteres)
        {
            bool numeroConfirmado = false;
            double numeroFinal = 0;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: Q. ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0)
                    {
                        if (double.TryParse(sb.ToString(), out double numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el monto de ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"Q. {numeroConvertido:F2}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();
                            if (respuesta == "yes")
                            {
                                numeroFinal = numeroConvertido;
                                numeroConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando monto", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando monto", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        else if (teclaInfo.KeyChar == '.' && !sb.ToString().Contains("."))
                        {
                            if (sb.Length == 0)
                            {
                                sb.Append("0.");
                                Console.Write("0.");
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }
    }
}
