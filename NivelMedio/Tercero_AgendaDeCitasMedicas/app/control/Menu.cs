using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.app.engine;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.app.control
{
    public class TerceroControl
    {
        public TerceroControl()
        {
            MostrarMenu();
        }
        Engine engine = new Engine();
        public void MostrarMenu()
        {
            Console.WriteLine("Para seleccionar alguna de las opciones debe presionar la tecla enter y el número correspondiente a la opción deseada.");
            Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Bienvenido a la Agenda de Citas Médicas");
            while (true)
            {
                Console.WriteLine("1. Registrar nueva cita");
                Console.WriteLine("2. Ver listado de citas");
                Console.WriteLine("3. Ver tutorial de uso");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = Convert.ToInt16(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        RegistrarCita();
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        engine.ListarCitas();
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Tutorial();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        public void RegistrarCita()
        {
            DateTime fecha = GetFecha();
            Console.Clear();

            Console.Write("Ingrese el nombre del paciente: ");
            string nombrePaciente = GetNombrePaciente();
            Console.Clear();

            Console.Write("Ingrese el tema de la cita: ");
            string tema = GetTema();
            Console.Clear();

            Console.Write("Ingrese una descripción (opcional): ");
            string? descripcion = Console.ReadLine();

            engine.AgregarCita(fecha, nombrePaciente, tema, descripcion);
        }
        
        public DateTime GetFecha()
        {
            while (true)
            {
                Console.WriteLine("lapsos disponibles a partir de este momento:");
                Console.WriteLine("1. 1 hora");
                Console.WriteLine("2. 2 horas");
                Console.WriteLine("3. 3 horas");
                Console.WriteLine("4. 1 dia");
                Console.WriteLine("5. 2 dias");
                Console.WriteLine("6. 3 dias");
                Console.WriteLine("7. 1 semana");
                Console.WriteLine("8. 1 mes");
                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine()!;
                if (!int.TryParse(entrada, out int opcion))
                {
                    Console.WriteLine("Entrada inválida. Intente de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case 1: return DateTime.Now.AddHours(1);
                    case 2: return DateTime.Now.AddHours(2);
                    case 3: return DateTime.Now.AddHours(3);
                    case 4: return DateTime.Now.AddDays(1);
                    case 5: return DateTime.Now.AddDays(2);
                    case 6: return DateTime.Now.AddDays(3);
                    case 7: return DateTime.Now.AddDays(7);
                    case 8: return DateTime.Now.AddMonths(1);
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        public string GetNombrePaciente()
        {
            while (true)
            {
                Console.Write("Ingrese el nombre del paciente: ");
                string? nombrePaciente = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(nombrePaciente))
                {
                    return nombrePaciente;
                }
                Console.WriteLine("El nombre del paciente no puede estar vacío. Intente de nuevo.");
            }
        }
        public string GetTema()
        {
            while (true)
            {
                Console.Write("Ingrese el tema de la cita: ");
                string? tema = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(tema))
                {
                    return tema;
                }
                Console.WriteLine("El tema de la cita no puede estar vacío. Intente de nuevo.");
            }
        }
        public void Tutorial()
        {
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("----- Tutorial de Uso -----");
            Console.WriteLine("1. Para registrar una nueva cita, seleccione la opción 1 en el menú principal.");
            Console.WriteLine("2. Ingrese la fecha y hora de la cita seleccionando uno de los lapsos disponibles.");
            Console.WriteLine("3. Proporcione el nombre del paciente y el tema de la cita.");
            Console.WriteLine("4. Puede agregar una descripción opcional para la cita.");
            Console.WriteLine("5. Para ver el listado de citas programadas, seleccione la opción 2 en el menú principal.");
            Console.WriteLine("6. Las citas se mostrarán ordenadas cronológicamente.");
            Console.WriteLine("7. Para salir del programa, seleccione la opción 3 en el menú principal.");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}