using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NivelMedio.clases.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string[]? NumeroTelefonico{ get; set; }
    }
}