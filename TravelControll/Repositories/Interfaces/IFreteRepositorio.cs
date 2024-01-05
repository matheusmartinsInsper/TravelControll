using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface IFreteRepositorio
    {
        Task<List<FreteModel>> ListaFretesUsuario(int id);
        Task<List<FreteModel>> ListaFretes();
        Task<FreteModel> AdicionarFrete(FreteModel frete);
        Task<FreteModel> AtualizaFrete(FreteModel frete, int idFrete);
        Task<FreteModel> AtualizaFreteAceito(FreteModel frete, int idFrete);
        Task<FreteModel> DeletarFrete(int idFrete);
        Task<FreteModel> BuscaFretePorId(int idFrete);
    }
}
