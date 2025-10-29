using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.directory;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.dto;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases
{
    public class Writer : Filepath
    {
        public void Escribir(List<CitaDto> cita)
        {
            MakeFile();
            using StreamWriter writer = new(filePath);
            
                string info = JsonSerializer.Serialize<List<CitaDto>>(cita, new JsonSerializerOptions{WriteIndented = true});
                writer.WriteLine(info);
        }
    }
}