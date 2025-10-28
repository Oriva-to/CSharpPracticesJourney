using NivelBasico.LevelBasicControler;
internal class Program
{
    private static void Main(string[] args)
    {
        LevelBasicController levelBasicController = new LevelBasicController();
        levelBasicController.RunCalculadora();
        levelBasicController.RunConvertidorTemperatura();
    }
}