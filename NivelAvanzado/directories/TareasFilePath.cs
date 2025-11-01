using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelAvanzado.directories
{
    public abstract class TareasFilePath
    {
        public readonly string filePath = Path.Combine(Environment.CurrentDirectory, "datosNivelAvanzado", "tareas.json");

        protected TareasFilePath()
        {
            CreateDirectoryIfNotExists();
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (!File.Exists(filePath))
            {
                using StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine("[]");
            }
        }
    }
}