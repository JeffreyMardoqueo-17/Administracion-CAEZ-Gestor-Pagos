using CAEZAdministracionFrontend.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace CAEZAdministracionFrontend.Services
{
    public class AdministradorService : IAdministradorService
    {
        private static string _baseUrl;
        public AdministradorService()
        {
            // Configuración de la URL base desde el archivo de configuración
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("config:baseUrl").Value;
        }
        // ELIMINAR
        public async Task<bool> DeleteAministrador(int idAdministrador)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync($"https://jsonplaceholder.typicode.com//posts/{idAdministrador}");

            if(response.IsSuccessStatusCode) 
            {
                respuesta = true;
            }
            return respuesta;


        }
        // OBTENER
        public async Task<Administrador> GetAdministrador(int idAdministrador)
        {
            Administrador objeto = new Administrador();

            // Configuración del cliente HTTP y envío de la solicitud GET para obtener un usuario por ID
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"https://jsonplaceholder.typicode.com/posts/{idAdministrador}");

            // Verificación del éxito de la operación y deserialización de la respuesta JSON
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonSerializer.Deserialize<Administrador>(json_respuesta);
                objeto = resultado;
            }
            return objeto;
        }

        public async Task<List<Administrador>> Lista()
        {
            List<Administrador> lista = new List<Administrador>();

             
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/posts");

            // Verificación del éxito de la operación y deserialización de la respuesta JSON
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                lista = JsonSerializer.Deserialize<List<Administrador>>(json_respuesta);
            }
            return lista;
        }
        // GUARDAR O CREAR UNO NUEVO
        public async Task<bool> PostAdministrador(Administrador administrador)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var jsonContent = JsonSerializer.Serialize(administrador);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("https://jsonplaceholder.typicode.com/posts/", content);

            if(response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        // ACTUALIZAR
        public async Task<bool> PutAdministrador(Administrador administrador)
        {
            bool respuesta = false;
           
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var jsonContent = JsonSerializer.Serialize(administrador);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("https://jsonplaceholder.typicode.com//posts/1", content);

             
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
