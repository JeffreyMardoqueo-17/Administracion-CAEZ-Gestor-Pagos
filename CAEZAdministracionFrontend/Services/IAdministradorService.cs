using CAEZAdministracionFrontend.Models;

namespace CAEZAdministracionFrontend.Services
{
    public interface IAdministradorService
    {
        // Método para obtener una lista de los Administradores
        Task<List<Administrador>> Lista();
        // Metodo para obtener informacion de un Administrador por su Id
        Task<Administrador> GetAdministrador(int idAdministrador);
        // Metodo para guardar un Administrador
        Task<bool> PostAdministrador(Administrador administrador);
        // Metodo para editar un Administrador existente
        Task<bool> PutAdministrador(Administrador administrador);
        // Metodo para eliminar un Administrador por su Id
        Task<bool> DeleteAministrador(int idAdministrador);

    }
}
