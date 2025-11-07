using System;
using CSharpPracticesJourney.NivelAvanzado.clases;
using CSharpPracticesJourney.NivelAvanzado.dtos;

namespace CSharpPracticesJourney.NivelAvanzado.app.engines
{
    public class SegundoAgendaTelefonica
    {
        private Writer<AgendaDto> writer = new("Agenda.Json");
        private Reader<AgendaDto> reader = new("Agenda.Json");
        private List<AgendaDto> agendas = new();
        public IReadOnlyList<AgendaDto> Agendas => agendas.AsReadOnly();
        SegundoAgendaTelefonica()
        {
            agendas = reader.ReadFromFile();
        }

        #region Metodos Principales
        public void AgregarContacto(string nombreCompleto, string numero, string correoElectronico, string notasAdicionales)
        {
            var nuevoContacto = new AgendaDto
            {
                Id = Agendas.Count > 0 ? Agendas.Max(c => c.Id) + 1 : 1,
                NombreCompleto = nombreCompleto,
                Numero = numero,
                CorreoElectronico = correoElectronico,
                NotasAdicionales = notasAdicionales
            };
            agendas.Add(nuevoContacto);
            writer.WriteToFile(agendas);
        }
        public void EditarContacto()
        {

        }
        public void EliminarContacto()
        {

        }
        #endregion
        //public AgendaDto GetContacto(){}
        #region Validaciones
        #endregion

    }
}