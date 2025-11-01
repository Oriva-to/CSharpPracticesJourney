using System;
using CSharpPracticesJourney.NivelBasico;

namespace CSharpPracticesJourney.NivelBasico.NivelBasicoController
{
    public class NivelBasicoController
    {
        public void RunCalculadora()
        {
            System.Console.WriteLine("***** Calculadora *****");
            System.Console.WriteLine("Solo dos numeros");

            System.Console.Write("Primer numero: ");
            int a = Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Segundo numero: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            Calculadora calculadora = new Calculadora(a, b);
            Console.WriteLine("------------------------------------------------");
            calculadora.Suma();
            calculadora.Resta();
            calculadora.Multiplicacion();
            calculadora.Division();
            Console.WriteLine("------------------------------------------------");
            Console.ReadLine();
        }
        public void RunConvertidorTemperatura()
        {
            System.Console.WriteLine("***** Convertidor de temperatura *****");
            System.Console.Write("Ingrese los grados centigrados a convertir: ");
            int grado = Convert.ToInt32(Console.ReadLine());

            ConvertidorTemperatura convertidor = new ConvertidorTemperatura(grado);
        }
    }
}