namespace TravelControll.Services.Interfaces
{
    public interface IRelatory<T>
    {
        Task<List<T>> BuscarDadosRelatorio(int id);
        void GerarRelatorio(int id);
    }
}
