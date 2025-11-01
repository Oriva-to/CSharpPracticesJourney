using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelAvanzado.directories;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.clases
{
    public class Writer:TareasFilePath
    {
        public void WriteToFile(List<TareaDto> tarea)
        {
            using (StreamWriter sw = new(filePath)){
                string info = JsonSerializer.Serialize(tarea, new JsonSerializerOptions { WriteIndented = true });
                sw.WriteLine(info);
            }
        }
    }
}