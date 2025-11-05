using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelAvanzado.directories
{
    public abstract class GeneralFilePath
    {
        public readonly string filePath;

        protected GeneralFilePath(string nombreArchivo)
        {
            filePath = Path.Combine(Environment.CurrentDirectory, "datosNivelAvanzado", nombreArchivo);
            CreateDirectoryIfNotExists();
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists("datosNivelAvanzado"))
            {
                Directory.CreateDirectory("datosNivelAvanzado");
            }
            if (!File.Exists(filePath))
            {
                using StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine("[]");
            }
        }
    }
}