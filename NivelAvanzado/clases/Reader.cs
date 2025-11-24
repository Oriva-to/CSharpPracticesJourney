using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelAvanzado.directories;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.clases
{
    public class Reader<T> : GeneralFilePath
    {
        public Reader(string nombreArchivo) : base(nombreArchivo)
        {
        }

        public List<T> ReadFromFile()
        {
            using (StreamReader sr = new(filePath))
            {
                string content = sr.ReadToEnd();

                try
                {
                    var tarea = JsonSerializer.Deserialize<List<T>>(content);
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