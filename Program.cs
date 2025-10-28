using NivelBasico.LevelBasiControler;
internal class Program
{
    private static void Main(string[] args)
    {
        LevelBasiController levelBasicController = new LevelBasiController();
        levelBasicController.RunCalculadora();
        levelBasicController.RunConvertidorTemperatura();
    }
}