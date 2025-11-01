using System;
using CSharpPracticesJourney.NivelAvanzado.enums;

namespace CSharpPracticesJourney.NivelAvanzado.dtos
{
    public class TareaDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public PrioridadTareas Prioridad { get; set; }
        public DateTime FechaLimite { get; set; }
        public Estadotareas Estado { get; set; }
    }
}