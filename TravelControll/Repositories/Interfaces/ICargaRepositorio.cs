using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface ICargaRepositorio
    {
        Task<List<CargaModel>> ListarTodasCargas();
        Task<List<CargaModel>> ListarCargasUsuario(int idUser);
        Task<CargaModel> AdicionarCarga(CargaModel carga);
        Task<CargaModel> AtualizarCarga(CargaModel carga, int IdCarga);
        Task<CargaModel> Apagar(int IdCarga);
        Task<CargaModel> BuscarCargaPorId(int IdCarga);
    }
}
