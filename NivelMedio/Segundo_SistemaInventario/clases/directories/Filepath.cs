using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.directories
{
    public class Filepath
    {
        public string filePath = Path.Combine("datosNivelMedio", "Segundo_SistemaInventario.json");

        
        public void CrearArchivo()
        {
            if (!Directory.Exists("datosNivelMedio"))
            {
                DirectoryInfo di = Directory.CreateDirectory("datosNivelMedio");
            }
            if (!File.Exists(filePath))
            {
                using StreamWriter file = new(filePath);
                file.Write("[]");
            }
        }
    }
}