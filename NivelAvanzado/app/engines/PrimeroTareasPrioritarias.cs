using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelAvanzado.clases;
using CSharpPracticesJourney.NivelAvanzado.dtos;
using CSharpPracticesJourney.NivelAvanzado.enums;

namespace CSharpPracticesJourney.NivelAvanzado.app.engines
{
    public class PrimeroTareasPrioritarias
    {
        private Writer writer = new("Tareas.Json");
        private Reader reader = new("Tareas.Json");
        private List<TareaDto> tarea = new();

        public List<TareaDto> Tarea { get => tarea; set => tarea = value; }
        public PrimeroTareasPrioritarias()
        {
            Tarea = reader.ReadFromFile();
        }

        public void SetTarea(string titulo, string? descripcion, PrioridadTareas prioridad, DateTime fechaLimite, Estadotareas? estado)
        {
            TareaDto nuevaTarea = new TareaDto
            {
                Id = Tarea.Count > 0 ? Tarea.Max(c => c.Id) + 1 : 1,
                Titulo = titulo,
                Descripcion = descripcion,
                Prioridad = prioridad,
                FechaLimite = fechaLimite,
                Estado = estado ?? Estadotareas.Pendiente
            };

            tarea.Add(nuevaTarea);
            var asd = tarea.OrderBy(t => t.Prioridad);
            writer.WriteToFile(asd.ToList());
            Console.WriteLine("Tarea agregada exitosamente.");
        }
        public void UpdateTarea(string? titulo = null, string? nuevoTitulo = null, string? descripcion = null, PrioridadTareas? prioridad = null, DateTime? fechaLimite = null, Estadotareas? estado = null)
        {
            var id = Tarea.FindIndex(t => t.Titulo == titulo);

            if (!string.IsNullOrEmpty(nuevoTitulo))
            {
                Tarea[id].Titulo = nuevoTitulo;
            }
            if (!string.IsNullOrEmpty(descripcion))
            {
                Tarea[id].Descripcion = descripcion;
            }
            if (prioridad != null)
            {
                Tarea[id].Prioridad = prioridad.Value;
            }
            if (fechaLimite != null)
            {
                Tarea[id].FechaLimite = fechaLimite.Value;
            }
            if (estado != null)
            {
                Tarea[id].Estado = estado.Value;
            }
            writer.WriteToFile(Tarea);
        }
        public void TareaCompletada(string titulo)
        {
            var id = Tarea.FindIndex(t => t.Titulo == titulo);
            if (id == -1)
            {
                System.Console.WriteLine("Tarea no encontrada.");
                return;
            }
            if (Tarea[id].Estado == Estadotareas.Completada)
            {
                System.Console.WriteLine("La tarea ya está completada.");
                return;
            }
            Tarea[id].Estado = Estadotareas.Completada;
            writer.WriteToFile(Tarea);
        }
        public void DeleteTarea(string titulo)
        {
            var tareaAEliminar = Tarea.FirstOrDefault(t => t.Titulo == titulo);
            if (tareaAEliminar != null)
            {
                Tarea.Remove(tareaAEliminar);
                writer.WriteToFile(Tarea);
                System.Console.WriteLine("Tarea eliminada exitosamente.");
                return;
            }
            System.Console.WriteLine("Tarea no encontrada.");
        }
    }
}