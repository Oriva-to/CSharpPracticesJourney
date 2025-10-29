using System;
using CSharpPracticesJourney.NivelMedio.Cuarto_JuegoAhorcado;
using CSharpPracticesJourney.NivelMedio.Primero_Gestordecontactos;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.app;
using CSharpPracticesJourney.NivelMedio.Tercero_AgendaDeCitasMedicas.app.control;

namespace CSharpPracticesJourney.NivelMedio.NivelMedioController
{
    public class NivelMedioController
    {
        public void RunPrimeroGestordecontactos()
        {
            Gestordecontactos gestor = new();
            gestor.Run();
        }
        public void RunSegundoSistemaInventario()
        {
            SegundoControl control = new();
        }
        public void RunTerceroAgendaDeCitasMedicas()
        {
            TerceroControl menu = new();
        }
        public void RunCuartoJuegoAhorcado()
        {
            JuegoAhorcado juego = new();
            juego.Run();
        }
    }
}