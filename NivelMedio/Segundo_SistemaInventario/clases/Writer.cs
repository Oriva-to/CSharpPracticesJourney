using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.directories;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.dto;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases
{
    public class Writer:Filepath
    {
        public void Escribir(List<ProductoDto> producto)
        {
            using StreamWriter writer = new(filePath);
            var productoToString = JsonSerializer.Serialize(producto, new JsonSerializerOptions { WriteIndented = true });
            writer.Write(productoToString);
        }
    }
}