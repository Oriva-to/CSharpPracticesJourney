using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.clases.dto;

namespace CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.app.engine
{
    public class Engine
    {
        Writer writer = new Writer();
        Reader reader = new Reader();
        public void AgregarCita(DateTime fecha, string nombrePaciente, string tema, string? descripcion = null)
        {
            List<CitaDto> citas = reader.Leer();
            bool existeCita = citas.Any(c => c.Fecha == fecha);
            if (existeCita)
            {
                Console.WriteLine("Ya existe una cita programada para esa fecha y hora. Por favor, elija otro horario.");
                return;
            }

            CitaDto nuevaCita = new CitaDto
            {
                Id = citas.Count > 0 ? citas.Max(c => c.Id) + 1 : 1,
                Fecha = fecha,
                NombrePaciente = nombrePaciente,
                Tema = tema,
                Descripcion = descripcion
            };

            citas.Add(nuevaCita);
            citas = citas.OrderBy(c => c.Fecha).ToList();
            writer.Escribir(citas);

            
            Console.WriteLine($"""
            Cita
            ID: {nuevaCita.Id}
            Fecha: {nuevaCita.Fecha}
            Paciente: {nuevaCita.NombrePaciente}
            Tema: {nuevaCita.Tema}
            Registrada exitosamente.
            """);
        }
        public void ListarCitas()
        {
            List<CitaDto> citas = reader.Leer();
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas programadas.");
                return;
            }

            Console.WriteLine("Listado de Citas:");
            foreach (var cita in citas)
            {
                Console.WriteLine($"ID: {cita.Id}, Fecha: {cita.Fecha}, Paciente: {cita.NombrePaciente}, Tema: {cita.Tema}, Descripción: {cita.Descripcion}");
            }
        }
    }
}