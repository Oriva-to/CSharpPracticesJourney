using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NivelBasico.clases
{
    public class ConvertidorTemperatura
    {
        private double celsius;
        private double fahrenheit;
        private double kelvin;

        public void GetGrados(int grado)
        {
            celsius = grado;
            fahrenheit = grado * 9 / 5 + 32;
            kelvin = grado + 273.15;

            System.Console.WriteLine("Grados celcius: " + celsius);
            System.Console.WriteLine("Grados fahrenheit: " + fahrenheit);
            System.Console.WriteLine("Grados kelvin: " + kelvin);
        }
    }
}