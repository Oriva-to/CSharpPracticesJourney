using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.directories;
using CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.clases.dto;
using Microsoft.VisualBasic;

namespace CSharpPracticesJourney.NivelMedio.Segundo_SistemaInventario.app
{
    public class Engine:Filepath
    {
        private Writer writer = new();
        private Reader reader = new();
        public Engine()
        {
            CrearArchivo();
        }
        public void ActualizarProducto(string nombreProducto, string? nuevoNombre = null, double? nuevoPrecio = null, int? nuevoStock = null)
        {
            List<ProductoDto> listaProductos = new();

            listaProductos = reader.GetProducto();

            var index = listaProductos.FindIndex(p => p.Nombre == nombreProducto);

            if (index == -1)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                listaProductos[index].Nombre = nuevoNombre;
            }
            if (nuevoPrecio.HasValue)
            {
                listaProductos[index].Precio = nuevoPrecio.Value;
            }
            if (nuevoStock.HasValue)
            {
                listaProductos[index].Stock = nuevoStock.Value;
            }

            writer.Escribir(listaProductos);
            Console.WriteLine("Producto actualizado correctamente");
        }
        public void EliminarProducto(string nombreProducto)
        {
            List<ProductoDto> listaProductos = new();

            listaProductos = reader.GetProducto();

            var index = listaProductos.FindIndex(p => p.Nombre == nombreProducto);

            if (index == -1)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }

            listaProductos.RemoveAll(p => p.Nombre == nombreProducto);

            writer.Escribir(listaProductos);
            Console.WriteLine("Producto eliminado correctamente");
        }
        public void Agregar(string nombre, double? precio = 0, int? stock = 0)
        {
            List<ProductoDto> listaProductos = new();

            listaProductos = reader.GetProducto();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El producto no puede estar con el parametro de nombre vacio");
                return;
            }

            var producto = new ProductoDto() { Nombre = nombre, Precio = precio!.Value, Stock = stock!.Value };

            listaProductos.Add(producto);

            writer.Escribir(listaProductos);
            Console.WriteLine("Producto agregado correctamente");
        }
        public void TodosLosProductos()
        {
            int contadorStock = 0;
            int contador = 0;
            
            List<ProductoDto> listaProductos = new();

            listaProductos = reader.GetProducto();

            foreach (var producto in listaProductos)
            {
                contador++;
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}");

                if (producto.Stock.HasValue)
                    contadorStock += producto.Stock.Value;
            }
            Console.WriteLine($"Total de productos: {contador}");
            Console.WriteLine($"Total de stock: {contadorStock}");
        }
    }
}