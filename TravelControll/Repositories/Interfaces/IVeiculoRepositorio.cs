using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<List<VeiculoModel>> ListarTodosVeiculos();
        Task<List<VeiculoModel>> ListarVeiculosUsuario(int idUser);
        Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo);
        Task<VeiculoModel> AtualizarVeiculo(VeiculoModel veiculo,int idVeiculo);
        Task<VeiculoModel> Apagar(int IdVeiculo);
        Task<VeiculoModel> BuscarVeiculoPorId(int IdVeiculo);
    }
}
