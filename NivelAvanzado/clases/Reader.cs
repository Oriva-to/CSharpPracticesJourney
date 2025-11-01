using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelAvanzado.directories;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.clases
{
    public class Reader : TareasFilePath
    {
        public TareaDto ReadFromFile()
        {
            using (StreamReader sr = new(filePath))
            {
                string content = sr.ReadToEnd();

                try
                {
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        throw new Exception("El archivo está vacío.");
                    }
                    var tarea = JsonSerializer.Deserialize<TareaDto>(content);
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