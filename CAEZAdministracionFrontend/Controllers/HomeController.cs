using CAEZAdministracionFrontend.Models;
using CAEZAdministracionFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CAEZAdministracionFrontend.Controllers
{
    public class HomeController : Controller
    {
        // Inyecci�n de dependencia del servicio que interact�a con la API
        private readonly IAdministradorService _administradorService;

        // Constructor del controlador que recibe una implementaci�n de IServicio_APIcs como par�metro
        public HomeController(IAdministradorService administradorService)
        {
            // Asigna el servicio proporcionado a la variable de clase
            _administradorService = administradorService;
        }

        // Acci�n del controlador para la p�gina de inicio
        public async Task<IActionResult> Index()
        {
            // Llama al m�todo Lista del servicio para obtener una lista de datos de la API
            List<Administrador> Lista = await _administradorService.Lista();
            // Devuelve la vista "Index" con la lista de datos como modelo
            return View(Lista);
        }

        // Acci�n del controlador para mostrar informaci�n de un usuario
        public async Task<IActionResult> Administrador(int idAdministrador)
        {
            // Instancia de model_API para representar un usuario
            Administrador administrador = new Administrador();

            // ViewBag para indicar que se est� creando un nuevo usuario
            ViewBag.Accion = "Nuevo Administrador";

            // Si el idAmdministrador no es 0, significa que se est� editando un usuario existente
            if (idAdministrador != 0)
            {
                // Llama al m�todo Obtener(idUsuario) del servicio para obtener informaci�n del usuario con el ID proporcionado
                administrador = await _administradorService.GetAdministrador(idAdministrador);

                // Indica que se est� editando un usuario
                ViewBag.Accion = "Editar Administrador";
            }

            // Devuelve la vista "Usuario" con el modelo(info) de usuario correspondiente
            return View(administrador);
        }

        // Acci�n del controlador para guardar cambios en un usuario
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Administrador ob_Administrador)
        {
            bool respuesta;

            // Verifica si el userId del usuario es igual a cero, lo cual indica que es un nuevo usuario
            if (ob_Administrador.Id == 0)
                // Llama al m�todo Guardar(ob_Usuario) del servicio para guardar un nuevo usuario
                respuesta = await _administradorService.PostAdministrador(ob_Administrador);
            else
                // Llama al m�todo Editar(ob_Usuario) del servicio para editar un usuario existente
                respuesta = await _administradorService.PutAdministrador(ob_Administrador);

            if (respuesta)
                // Verifica la respuesta del servicio y redirige a la p�gina de inicio si es exitosa
                return RedirectToAction("Index");
            else
                // Si la operaci�n falla, devuelve una respuesta sin contenido
                return NoContent();
        }

        // Acci�n del controlador para eliminar un usuario
        [HttpGet]
        public async Task<IActionResult> Eliminar(int idAdministrador)
        {
            // Llama al m�todo Eliminar(idUsuario) del servicio para eliminar un usuario
            var respuesta = await _administradorService.DeleteAministrador(idAdministrador);

            if (respuesta)
                // Verifica la respuesta del servicio y redirige a la p�gina de inicio si es exitosa
                return RedirectToAction("Index");
            else
                // Si la operaci�n falla, devuelve una respuesta sin contenido
                return NoContent();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}