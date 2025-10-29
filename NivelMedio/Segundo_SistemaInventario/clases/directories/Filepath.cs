using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.directories
{
    public class Filepath
    {
        public string filePath = Path.Combine("datos", "Segundo_SistemaInventario.json");

        
        public void CrearArchivo()
        {
            if (!Directory.Exists("datos"))
            {
                DirectoryInfo di = Directory.CreateDirectory("datos");
            }
            if (!File.Exists(filePath))
            {
                using StreamWriter file = new(filePath);
                file.Write("[]");
            }
        }
    }
}