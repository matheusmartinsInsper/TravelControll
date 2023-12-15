using Microsoft.EntityFrameworkCore;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Repositories
{
    public class FreteRepositorio : IFreteRepositorio
    {
        private readonly TravelControllContextDb _context;
        public FreteRepositorio(TravelControllContextDb context)
        {
            _context = context;
        }
        public Task<FreteModel> AdicionarFrete(FreteModel frete)
        {
            throw new NotImplementedException();
        }

        public Task<FreteModel> AtualizaFrete(FreteModel frete, int idFrete)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FreteModel>> ListaFretesUsuario(int id)
        {
            List<FreteModel> fretes = await _context.Frete.Where(x => x.id_empresa == id)
                                                          .ToListAsync();
            var veiculos = await _context.Fretes.FromSqlRaw("select * from veiculosfretes").ToListAsync();
            Console.WriteLine(veiculos);
            return fretes;
        }
    }
}
