using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.dto
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public int? Stock { get; set; }
    }
}