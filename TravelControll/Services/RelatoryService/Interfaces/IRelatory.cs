using TravelControll.Models;

namespace TravelControll.Services.RelatoryService.Interfaces
{
    public interface IRelatory<T>
    {
        Task<List<T>> BuscarDadosRelatorio(int id);
        void GerarRelatorio(int id, string date);
        Task<List<UsuarioModel>> UsuariosRelatorio();
    }
}
