using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.directories;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.dto;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases
{
    public class Reader:Filepath
    {
        public List<ProductoDto> GetProducto()
        {
            CrearArchivo();

            List<ProductoDto> productos = new();
            using StreamReader reader = new(filePath);
            var contenido = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new InvalidDataException("El archivo está vacío o no contiene información válida.");
            }
            productos = JsonSerializer.Deserialize<List<ProductoDto>>(contenido)!;
            
            return productos; 
        }
        
    }
}