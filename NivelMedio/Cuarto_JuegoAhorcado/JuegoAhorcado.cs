/*
    9. Juego del ahorcado

    Conceptos: Bucles, strings, condicionales, modularización.

    Requisitos: Mostrar progreso de letras acertadas, limitar intentos, y validar letras repetidas.

    Resultado esperado: Juego jugable con palabras almacenadas en una lista o archivo.
*/
namespace CSharpPracticesJourney.NivelMedio.Cuarto_JuegoAhorcado
{
    public class JuegoAhorcado
    {
        public void Run()
        {
            string[] palabras = { "programacion", "desarrollo", "computadora", "teclado", "monitor" };
            Random rand = new Random();
            string palabraSecreta = palabras[rand.Next(palabras.Length)];
            char[] progreso = new string('_', palabraSecreta.Length).ToCharArray();
            int intentosRestantes = 6;
            List<char> letrasUsadas = new List<char>();
            Console.WriteLine("¡Bienvenido al juego del ahorcado!");

            while (intentosRestantes > 0 && new string(progreso) != palabraSecreta)
            {
                Console.WriteLine($"\nPalabra: {new string(progreso)}");
                Console.WriteLine($"Intentos restantes: {intentosRestantes}");
                Console.WriteLine($"Letras usadas: {string.Join(", ", letrasUsadas)}");
                Console.Write("Ingresa una letra: ");
                char letra = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya has usado esa letra. Intenta con otra.");
                    continue;
                }

                letrasUsadas.Add(letra);

                if (palabraSecreta.Contains(letra))
                {
                    for (int i = 0; i < palabraSecreta.Length; i++)
                    {
                        if (palabraSecreta[i] == letra)
                        {
                            progreso[i] = letra;
                        }
                    }
                    Console.WriteLine("¡Correcto!");
                }
                else
                {
                    intentosRestantes--;
                    Console.WriteLine("¡Incorrecto!");
                }
                if (new string(progreso) == palabraSecreta)
                {
                    Console.WriteLine($"\n¡Felicidades! Has adivinado la palabra: {palabraSecreta}");
                }
                else if (intentosRestantes == 0)
                {
                    Console.WriteLine($"\nHas perdido. La palabra era: {palabraSecreta}");
                }
            }
        }
    }
}