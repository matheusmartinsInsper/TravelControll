using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Repositories
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly TravelControllContextDb _context;
        public VeiculoRepositorio(TravelControllContextDb context)
        {
            _context = context;
        }
        public async Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo)
        {
            await _context.Veiculo.AddAsync(veiculo);
            _context.SaveChanges();
            return veiculo;
        }

        public async Task<VeiculoModel> Apagar(int IdVeiculo)
        {
            VeiculoModel veiculo = await BuscarVeiculoPorId(IdVeiculo);
            if (veiculo != null)
            {
                _context.Veiculo.Remove(veiculo);
                _context.SaveChanges();
                return veiculo;
            }
            return null;
        }

        public async Task<VeiculoModel> AtualizarVeiculo(VeiculoModel veiculo, int idVeiculo)
        {
            VeiculoModel veiculoId = await BuscarVeiculoPorId(idVeiculo);
            if (veiculoId != null)
            {
                Type tipoVeiculo = veiculoId.GetType();
                PropertyInfo[] propriedades = tipoVeiculo.GetProperties();
                foreach (PropertyInfo prop in propriedades)
                {
                    prop.SetValue(veiculoId, prop.GetValue(veiculo));
                }
                _context.Veiculo.Update(veiculoId);
                _context.SaveChanges();
                return veiculoId;
            }
            return null;
        }

        public async Task<VeiculoModel> BuscarVeiculoPorId(int IdVeiculo)
        {
            return await _context.Veiculo.Include(x => x.UsuarioModel)
                                         .FirstOrDefaultAsync(x => x.id == IdVeiculo);
        }

        public async Task<List<VeiculoModel>> ListarTodosVeiculos()
        {
            return await _context.Veiculo.Include(x=>x.UsuarioModel)
                                         .ToListAsync();
        }

        public async Task<List<VeiculoModel>> ListarVeiculosUsuario(int idUser)
        {
            return await _context.Veiculo.Where(x=>x.id_usuario==idUser)
                                         .Include(x => x.UsuarioModel)
                                         .ToListAsync();
        }
    }
}
