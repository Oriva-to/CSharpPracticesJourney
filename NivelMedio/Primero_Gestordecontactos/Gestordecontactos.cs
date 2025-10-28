using System.Text.Json;
using NivelMedio.clases.Dto;

namespace NivelMedio.Primero_Gestordecontactos
{
    public class Gestordecontactos
    {
        public void Run()
        {
            var path = @"datos\PrimeroGestordecontactos.json";
            
            if (!Directory.Exists("datos"))
            {
                DirectoryInfo di = Directory.CreateDirectory("datos");
            }

            Dictionary<string, PersonaDto> persona = new();
            string[] numero = ["809-000-0004", "555-000-3333"];
            var usuario1 = new PersonaDto()
            {
                Id = 1,
                Nombre = "Carlos",
                Apellido = "Motero",
                //NumeroTelefonico = numero
            };
            var usuario2 = new PersonaDto()
            {
                Id = 2,
                Nombre = "Jorge",
                Apellido = "Zantana",
                NumeroTelefonico = numero
            };
            persona.Add("Ingeniero", usuario1);
            persona.Add("Cansiller", usuario2);
            persona.Add("Policia", usuario2);
            persona.Add("Guardia", usuario2);

            Escribir(persona, path);
            //lectura(path, "Cansiller");
            //Editar(path, "Cansiller", usuario2);
            //Eliminar(path, "Cansiller");
        }

        public void Escribir(Dictionary<string, PersonaDto> usuario, string path)
        {
            string info = JsonSerializer.Serialize(usuario, new JsonSerializerOptions { WriteIndented = true });
            using StreamWriter Writer = new(path);
            Writer.WriteLine(info);
            Writer.Close();

        }
        public void lectura(string path, string usuarioFiltrado)
        {
            Dictionary<string, PersonaDto> usuario = new();
            using StreamReader reader = new(path);
            var contenido = reader.ReadToEnd();
            reader.Close();

            usuario = JsonSerializer.Deserialize<Dictionary<string, PersonaDto>>(contenido)!;

            var dataUsuario = JsonSerializer.Serialize(usuario[usuarioFiltrado], new JsonSerializerOptions { WriteIndented = true });

            System.Console.WriteLine(dataUsuario);
        }
        public void Editar(string path, string usuarioFiltrado, PersonaDto update)
        {
            Dictionary<string, PersonaDto> usuario = new();
            using StreamReader reader = new(path);
            var contenido = reader.ReadToEnd();
            reader.Close();

            usuario = JsonSerializer.Deserialize<Dictionary<string, PersonaDto>>(contenido)!;

            if (!usuario.ContainsKey(usuarioFiltrado))
            {
                return;
            }

            usuario[usuarioFiltrado] = update;

            Escribir(usuario, path);
        }
        public void Eliminar(string path, string usuarioFiltrado)
        {
            Dictionary<string, PersonaDto> usuario = new();
            using StreamReader reader = new(path);
            var contenido = reader.ReadToEnd();
            reader.Close();
            usuario = JsonSerializer.Deserialize<Dictionary<string, PersonaDto>>(contenido)!;

            if (!usuario.ContainsKey(usuarioFiltrado))
            {
                return;
            }

            usuario.Remove(usuarioFiltrado);

            Escribir(usuario, path);
        }

    }

}