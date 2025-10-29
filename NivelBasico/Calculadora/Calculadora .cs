using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelBasico.Calculadora
{
    public class Calculadora
    {
        double a;
        int b;
        public Calculadora(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void Suma()
        {
            System.Console.WriteLine("El resultado de la suma es: " + (a + b));
        }
        public void Resta()
        { 
            System.Console.WriteLine("El resultado de la resta es: " + (a - b));
        }
        public void Multiplicacion()
        { 
            System.Console.WriteLine("El resultado de la multiplicacion es: " + (a * b));
        }
        public void Division()
        {
            System.Console.WriteLine("El resultado de la divicion es: " + (a / b));
        }
        
    }
}