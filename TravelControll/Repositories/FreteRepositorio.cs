using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

        public async Task<FreteModel> AtualizaFrete(FreteModel frete, int idFrete)
        {
            FreteModel freteId = await BuscaFretePorId(idFrete);
            if (freteId != null)
            {
                Type tipoFrete = frete.GetType();
                PropertyInfo[] propriedades = tipoFrete.GetProperties();
                foreach(PropertyInfo prop in propriedades)
                {
                    prop.SetValue(freteId, prop.GetValue(frete));
                }
                _context.Frete.Update(freteId);
                _context.SaveChanges();
                return freteId;
            }
            return null;
        }

        public async Task<FreteModel> AtualizaFreteAceito(FreteModel frete, int idFrete)
        {
            FreteModel freteId = await BuscaFretePorId(idFrete);
            freteId.id_motorista = frete.id_motorista;
            freteId.id_veiculo_motorista = frete.id_veiculo_motorista;
            frete.status = "Aceito";
            _context.Frete.Update(freteId);
            _context.SaveChanges();
            return freteId;
        }

        public async Task<FreteModel> BuscaFretePorId(int idFrete)
        {
            return await _context.Frete
                .Include(x => x.UsuarioModel)
                .FirstOrDefaultAsync(x => x.id == idFrete);
        }

        public async Task<FreteModel> DeletarFrete(int idFrete)
        {
            FreteModel freteId = await BuscaFretePorId(idFrete);
            _context.Frete.Remove(freteId);
            _context.SaveChanges(); 
             return freteId;          
        }

        public async Task<List<FreteModel>> ListaFretes()
        {
            List<FreteModel> fretes = await _context.Frete.Include(x => x.veiculo)
                                                          .Include(x=>x.carga)
                                                          .ToListAsync();
            return fretes;
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
