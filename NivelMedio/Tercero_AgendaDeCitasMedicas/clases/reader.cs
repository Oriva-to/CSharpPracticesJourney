using System;
using System.Text.Json;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.directory;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.dto;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases
{
    public class Reader:Filepath
    {
        public List<CitaDto> Leer()
        {
            MakeFile();
            using(StreamReader reader = new StreamReader(filePath))
            {
                string info = reader.ReadToEnd();
                var citas = JsonSerializer.Deserialize<List<CitaDto>>(info);
                return citas!;
            }
        }
    }
}