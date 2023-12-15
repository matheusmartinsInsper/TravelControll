using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface IFreteRepositorio
    {
        Task<List<FreteModel>> ListaFretesUsuario(int id);
        Task<FreteModel> AdicionarFrete(FreteModel frete);
        Task<FreteModel> AtualizaFrete(FreteModel frete, int idFrete); 
    }
}
