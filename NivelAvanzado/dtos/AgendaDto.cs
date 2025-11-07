using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelAvanzado.dtos
{
    public class AgendaDto
    {
        public int Id { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Numero { get; set; }
        public required string CorreoElectronico { get; set; }
        public string? NotasAdicionales { get; set; }
    }
}