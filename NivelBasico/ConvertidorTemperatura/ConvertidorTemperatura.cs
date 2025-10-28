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

        public ConvertidorTemperatura(int grado)
        {
            celsius = grado;
            fahrenheit = grado * 9 / 5 + 32;
            kelvin = grado + 273.15;

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Grados celcius: {0}℃", celsius);
            Console.WriteLine("Grados fahrenheit: {0}℉", fahrenheit);
            Console.WriteLine("Grados kelvin: {0}°K", kelvin);
            Console.WriteLine("------------------------------------------------");
            Console.ReadLine();
        }
    }
}