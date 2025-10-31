using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.directory
{
    public class Filepath
    {
        public readonly string filePath = Path.Combine(Environment.CurrentDirectory, "datosNivelMedio", "Tercero_AgendaDeCitasMedicas.json");

        public void MakeFile()
        {
            if (!Directory.Exists("datosNivelMedio"))
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory("datosNivelMedio");
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }

            }
            if (!File.Exists(filePath))
            {
                using StreamWriter file = new(filePath);
                file.Write("[]");
            }
        }
    }
}