using Microsoft.AspNetCore.Mvc;
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
        public async Task<FreteModel> AdicionarFrete(FreteModel frete)
        {
            await _context.Frete.AddAsync(frete);
            _context.SaveChanges();
            return frete;
        }

        public Task<FreteModel> AtualizaFrete(FreteModel frete, int idFrete)
        {
            throw new NotImplementedException();
        }

        public async Task<FreteModel> BuscaFretePorId(int idFrete)
        {
            return await _context.Frete
                .Include(x => x.UsuarioModel)
                .FirstOrDefaultAsync(x => x.Id == idFrete);
        }

        public async Task<Response> DeletarFrete(int idFrete)
        {
            Response deletResponse = new Response();
            FreteModel freteId = await BuscaFretePorId(idFrete);
            if (freteId == null)
            {
                deletResponse.status = "error";
                deletResponse.message = "Frete não encontrato";
                return deletResponse;
            }
            else
            {
                _context.Frete.Remove(freteId);
                _context.SaveChanges();
                deletResponse.status = "Ok";
                deletResponse.message = "Frete deletado com sucesso";
                return deletResponse;
            }
        }

        public async Task<List<FreteModel>> ListaFretesUsuario(int id)
        {
            List<FreteModel> fretes = await _context.Frete.Where(x => x.id_empresa == id)
                                                          .Include(x=>x.veiculo)
                                                          .ToListAsync();
            return fretes;
        }
    }
}
