using CSharpPracticesJourney.NivelMedio.NivelMedioController;
using CSharpPracticesJourney.NivelBasico.NivelBasicoController;
using CSharpPracticesJourney.NivelAvanzado.app.controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        //NivelBasicoController levelBasicController = new();
        // levelBasicController.RunCalculadora();
        // levelBasicController.RunConvertidorTemperatura();

        //NivelMedioController nivelMedioController = new();
        //nivelMedioController.RunPrimeroGestordecontactos();
        //nivelMedioController.RunSegundoSistemaInventario();
        //nivelMedioController.RunTerceroAgendaDeCitasMedicas();
        //nivelMedioController.RunCuartoJuegoAhorcado();

        //PrimeroTareasController primeroTareasController = new();
        SegundoAgendaTelefonicaController segundoAgenda = new();
        //segundoAgenda.Rum();
        segundoAgenda.chequeo();
        
        
    }
}