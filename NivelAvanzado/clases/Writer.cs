using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelAvanzado.directories;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.clases
{
    public class Writer:TareasFilePath
    {
        public void WriteToFile(TareaDto tarea)
        {
            using (StreamWriter sw = File.AppendText(filePath)){
                string info = JsonSerializer.Serialize(tarea, new JsonSerializerOptions { WriteIndented = true });
                sw.WriteLine(info);
            }
        }
    }
}