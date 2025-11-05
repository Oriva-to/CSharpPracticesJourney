using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelAvanzado.directories;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.clases
{
    public class Reader : GeneralFilePath
    {
        public Reader(string nombreArchivo) : base(nombreArchivo)
        {
        }

        public List<TareaDto> ReadFromFile()
        {
            using (StreamReader sr = new(filePath))
            {
                string content = sr.ReadToEnd();

                try
                {
                    var tarea = JsonSerializer.Deserialize<List<TareaDto>>(content);
                    return tarea!;
                }
                catch (JsonException ex)
                {
                    throw new Exception("Error al deserializar el contenido del archivo.", ex);
                }

            }
        }
    }
}