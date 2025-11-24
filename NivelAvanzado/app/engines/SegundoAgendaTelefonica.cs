using System;
using CSharpPracticesJourney.NivelAvanzado.clases;
using CSharpPracticesJourney.NivelAvanzado.dtos;
using System.Text.RegularExpressions;

namespace CSharpPracticesJourney.NivelAvanzado.app.engines
{
    public class SegundoAgendaTelefonica
    {
        private Writer<AgendaDto> writer = new("Agenda.Json");
        private Reader<AgendaDto> reader = new("Agenda.Json");
        private List<AgendaDto> agendas = new();
        public IReadOnlyList<AgendaDto> Agendas => agendas.AsReadOnly();
        public SegundoAgendaTelefonica()
        {
            agendas = reader.ReadFromFile();
        }

        #region Metodos Principales
        public void AgregarContacto(string nombreCompleto, string numero, string correoElectronico, string? notasAdicionales = null)
        {
            var nuevoContacto = new AgendaDto
            {
                Id = agendas.Count > 0 ? agendas.Max(c => c.Id) + 1 : 1,
                NombreCompleto = nombreCompleto,
                Numero = numero,
                CorreoElectronico = correoElectronico,
                NotasAdicionales = notasAdicionales
            };
            agendas.Add(nuevoContacto);
            writer.WriteToFile(agendas);
        }
        public void EditarAgenda(int id)
        {
            var agenda = agendas.FirstOrDefault(p => p.Id == id);
            if(agenda == null)
            {
                System.Console.WriteLine("la agenda no existe");
                return;
            }

        }
        public void EliminarContacto()
        {
        }

        //public AgendaDto GetContacto(){}
        #endregion
        #region Validaciones
        //Existe para no repetir un usuario existente
        //id para optener un usuario existente
        public (bool existe, int id, string nombre, string numero) ExisteContacto(string nombre, string numero)
        {
            bool existe = true;
            int id = 0;

            string patternNombre = string.IsNullOrWhiteSpace(nombre)
                ? string.Empty
                : Regex.Escape(nombre.Trim());

            string patternNumero = string.IsNullOrWhiteSpace(numero)
                ? string.Empty
                : Regex.Escape(numero.Trim());

            var resultados = agendas
                .Where(item => Regex.IsMatch(item.NombreCompleto, patternNombre, RegexOptions.IgnoreCase)
                    && Regex.IsMatch(item.Numero, patternNumero, RegexOptions.IgnoreCase))
                .ToList();

            if (resultados.Count == 1)
            {
                foreach (var item in resultados)
                {
                    id = item.Id;
                }
            }
            else if (resultados.Count > 1)
            {
                List<AgendaDto> agendasTemporales = [];
                foreach (var item in resultados)
                {
                    agendasTemporales.Add(item);

                    if (agendasTemporales.Count == resultados.Count)
                    {
                        id = MasDeUnResultado(agendasTemporales);
                    }
                }
            }
            else
            {
                existe = false;
                //return (existe, id,nombre,numero);
            }
            return (existe, id, nombre, numero);
        }
        private int MasDeUnResultado(List<AgendaDto> agenda)
        {
            int id = 0;
            System.Console.WriteLine("Hay mas de una agenda con coindidencias, seleccione el [id] de la agenda que usara");
            while (true)
            {
                foreach (var item in agenda)
                {
                    System.Console.WriteLine($"[Id]: {item.Id}, [Nombre]: {item.NombreCompleto}, [Numero]: {item.Numero}");
                }
                id = Convert.ToInt32(Console.ReadLine());
                if (!agenda.Any(p => p.Id == id))
                {
                    System.Console.WriteLine("El [id] seleccionado no corresponde a ninguno de los sugeridos, vuelva a intentarlo");
                    continue;
                }
                else
                {
                    break;
                }
            }

            return id;
        }
        #endregion

    }
}