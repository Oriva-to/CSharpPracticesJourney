using NivelBasico.LevelBasiControler;
using NivelMedio.Primero_Gestordecontactos;
internal class Program
{
    private static void Main(string[] args)
    {
        // LevelBasiController levelBasicController = new LevelBasiController();
        // levelBasicController.RunCalculadora();
        // levelBasicController.RunConvertidorTemperatura();

        Gestordecontactos gestor = new();
        gestor.Run();
    }
}