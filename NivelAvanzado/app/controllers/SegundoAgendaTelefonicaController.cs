using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelAvanzado.app.engines;

namespace CSharpPracticesJourney.NivelAvanzado.app.controllers
{
    public class SegundoAgendaTelefonicaController
    {
        SegundoAgendaTelefonica agendaTelefonica = new();

        public void Rum()
        {
            var nombre = agendaTelefonica.ExisteContacto("abc2503g","120345645689");
            if(nombre.existe == false)
            agendaTelefonica.AgregarContacto(nombre.nombre,nombre.numero,"");
            System.Console.WriteLine(nombre.id + nombre.nombre + nombre.existe);
        }
        public void chequeo()
        {
            agendaTelefonica.ExisteContacto("abc","123");
        }
        
    }
}