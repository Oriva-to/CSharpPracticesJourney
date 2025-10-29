using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.app
{
    public class SegundoControl
    {
        Engine engine = new();
        public SegundoControl()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema de inventario");

            while (true)
            {
                Console.WriteLine("opciones actialmente disponibles:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Ver todos los productos");
                Console.WriteLine("5. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        ActualizarProducto();
                        break;
                    case "3":
                        EliminarProducto();
                        break;
                    case "4":
                        VerTodosLosProductos();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }

        }
        private void AgregarProducto()
        {
            Console.Write("Ingrese el nombre del producto: ");
            var nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            var precio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el stock del producto: ");
            var stock = Convert.ToInt32(Console.ReadLine());

            engine.Agregar(nombre, precio, stock);
        }
        private void ActualizarProducto()
        {
            Console.Write("Ingrese el nombre del producto a actualizar: ");
            var nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo nombre del producto (deje en blanco para no cambiar): ");
            var nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo precio del producto (deje en blanco para no cambiar): ");
            var nuevoPrecioInput = Console.ReadLine();
            double? nuevoPrecio = string.IsNullOrWhiteSpace(nuevoPrecioInput) ? null : Convert.ToDouble(nuevoPrecioInput);

            Console.Write("Ingrese el nuevo stock del producto (deje en blanco para no cambiar): ");
            var nuevoStockInput = Console.ReadLine();
            int? nuevoStock = string.IsNullOrWhiteSpace(nuevoStockInput) ? null : Convert.ToInt32(nuevoStockInput);

            engine.ActualizarProducto(nombre, nuevoNombre, nuevoPrecio, nuevoStock);
        }
        private void EliminarProducto()
        {
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            var nombre = Console.ReadLine();

            engine.EliminarProducto(nombre);
        }
        private void VerTodosLosProductos()
        {
            engine.TodosLosProductos();
        }
    }
}