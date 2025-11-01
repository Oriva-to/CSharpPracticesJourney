using System;
using CSharpPracticesJourney.NivelAvanzado.app.engines;
using CSharpPracticesJourney.NivelAvanzado.enums;

namespace CSharpPracticesJourney.NivelAvanzado.app.controllers
{
    public class PrimeroTareasController
    {
        PrimeroTareasPrioritarias tareasPrioritarias = new();
        public PrimeroTareasController()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Actualizar Tarea");
                Console.WriteLine("3. Completar Tarea");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Mostrar Tareas");
                Console.WriteLine("6. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        ActualizarTarea();
                        break;
                    case "3":
                        TareaCompletada();
                        break;
                    case "4":
                        EliminarTarea();
                        return;
                    case "5":
                        MostrarTareas();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        private void AgregarTarea()
        {
            string titulo = AgregarTitulo();
            string descripcion = AgregarDescripcion();
            PrioridadTareas prioridad = AgregarPrioridad();
            DateTime fechaLimite = AgregarFechaLimite();

            tareasPrioritarias.SetTarea(titulo, descripcion, prioridad, fechaLimite, null);
        }
        private void ActualizarTarea()
        {
            Console.Write("Ingrese el título de la tarea a actualizar:");
            string tituloActual = Console.ReadLine() ?? "";
            string nuevoTitulo = "";

            if (!tareasPrioritarias.Tarea.Any(t => t.Titulo.Equals(tituloActual, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("La tarea no existe.");
                return;
            }

            //string nuevoTitulo = AgregarTitulo();
            while (true)
            {
                Console.WriteLine("Ingrese el nuevo título de la tarea:");
                nuevoTitulo = Console.ReadLine() ?? "";

                if (GetTareaExistente(nuevoTitulo, tituloActual))
                {
                    continue;
                }
                break;
            }

            string nuevaDescripcion = AgregarDescripcion();
            PrioridadTareas nuevaPrioridad = AgregarPrioridad();
            DateTime nuevaFechaLimite = AgregarFechaLimite();

            tareasPrioritarias.UpdateTarea(tituloActual, nuevoTitulo, nuevaDescripcion, nuevaPrioridad, nuevaFechaLimite, null);
        }
        private void TareaCompletada()
        {
            Console.Write("Ingrese el título de la tarea completada:");
            string titulo = Console.ReadLine() ?? "";

            tareasPrioritarias.TareaCompletada(titulo);
        }
        private void EliminarTarea()
        {
            Console.Write("Ingrese el título de la tarea a eliminar:");
            string titulo = Console.ReadLine() ?? "";

            tareasPrioritarias.DeleteTarea(titulo);
        }
        private void MostrarTareas()
        {
            var tareas = tareasPrioritarias.Tarea;

            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas disponibles.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            foreach (var tarea in tareas)
            {
                string infoTarea = $"""
                    [ID: {tarea.Id}] Título: {tarea.Titulo}
                    Prioridad: {tarea.Prioridad.ToString()} | Estado : {tarea.Estado.ToString()} | Fecha Límite: {tarea.FechaLimite}
                    Descripción: {tarea.Descripcion}
                    """;

                Console.WriteLine(new string('-', 50));
                Console.WriteLine(infoTarea);
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine("Numero total de tareas: " + tareas.Count);
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
        private string AgregarTitulo()
        {
            string titulo;

            do
            {
                Console.WriteLine("Ingrese el título de la tarea:");
                titulo = Console.ReadLine() ?? "";

                if (GetTareaExistente(titulo))
                {
                    continue;
                }

                break;

            } while (true);

            return titulo;
        }
        private string AgregarDescripcion()
        {
            Console.WriteLine("Ingrese la descripción de la tarea:");
            return Console.ReadLine() ?? "";
        }
        private PrioridadTareas AgregarPrioridad()
        {
            Console.WriteLine("Ingrese la prioridad de la tarea ( 1:Baja, 2:Media, 3:Alta) media por defecto:");
            var prioridadInput = Convert.ToInt16(Console.ReadLine());

            return prioridadInput switch
            {
                1 => PrioridadTareas.Baja,
                2 => PrioridadTareas.Media,
                3 => PrioridadTareas.Alta,
                _ => PrioridadTareas.Media,
            };
        }
        private DateTime AgregarFechaLimite()
        {
            Console.WriteLine("Ingrese la fecha límite de la tarea");
            Console.WriteLine("");

            Console.Write("Dias desde hoy: ");
            int diasInput = int.TryParse(Console.ReadLine(), out int dias) ? dias : 0;

            Console.Write("Horas desde ahora: ");
            int horasInput = int.TryParse(Console.ReadLine(), out int horas) ? horas : 0;

            Console.Write("Minutos desde ahora: ");
            int minutosInput = int.TryParse(Console.ReadLine(), out int minutos) ? minutos : 0;

            DateTime fechaLimite = DateTime.Now.AddDays(diasInput).AddHours(horasInput).AddMinutes(minutosInput);

            return fechaLimite;
        }
        private bool GetTareaExistente(string titulo, string? tituloActual = null)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título no puede estar vacío. Por favor, ingrese un título válido.");
                return true;
            }

            // Permite que al editar, el mismo título actual no se considere duplicado
            if (tituloActual != null && titulo.Equals(tituloActual, StringComparison.OrdinalIgnoreCase))
                return false;

            var tareaExistente = tareasPrioritarias.Tarea
                .FirstOrDefault(t => t.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (tareaExistente != null)
            {
                Console.WriteLine("El título de la tarea ya existe. Por favor, ingrese un título diferente.");
                return true;
            }

            return false;
        }
    }
}
