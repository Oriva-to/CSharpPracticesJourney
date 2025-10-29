using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.dto
{
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today.AddDays(1);
        public string NombrePaciente { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}