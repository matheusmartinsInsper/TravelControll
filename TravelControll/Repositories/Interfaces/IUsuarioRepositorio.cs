using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorID(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizaUsuario(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
