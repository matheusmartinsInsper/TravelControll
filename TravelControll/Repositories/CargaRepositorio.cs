using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Repositories
{
    public class CargaRepositorio:ICargaRepositorio
    {
        private readonly TravelControllContextDb _context;
        public CargaRepositorio(TravelControllContextDb context)
        {
            _context = context;
        }

        public async Task<CargaModel> AdicionarCarga(CargaModel carga)
        {
            await _context.Carga.AddAsync(carga);
            _context.SaveChanges();
            return carga;
        }

        public async Task<CargaModel> Apagar(int IdCarga)
        {
            CargaModel cargaId = await BuscarCargaPorId(IdCarga);
            if(cargaId != null)
            {
                _context.Carga.Remove(cargaId); 
                _context.SaveChanges();
                return cargaId;
            }
            return null;
        }

        public async Task<CargaModel> AtualizarCarga(CargaModel carga, int IdCarga)
        {
            CargaModel cargaId = await BuscarCargaPorId(IdCarga);
            if (cargaId != null)
            {
                Type tipoVeiculo = cargaId.GetType();
                PropertyInfo[] propriedades = tipoVeiculo.GetProperties();
                foreach (PropertyInfo prop in propriedades)
                {
                    if (prop.GetValue(carga) != null)
                    {
                       prop.SetValue(cargaId, prop.GetValue(carga));
                    }
                }
                _context.Carga.Update(cargaId);
                _context.SaveChanges();
                return cargaId;
            }
            return null;
        }

        public async Task<CargaModel> BuscarCargaPorId(int IdCarga)
        {
            return await _context.Carga.FirstOrDefaultAsync(x => x.id == IdCarga);
        }

        public async Task<List<CargaModel>> ListarCargasUsuario(int idUser)
        {
            return await _context.Carga.Where(x => x.id_empresa == idUser)
                                         .Include(x => x.UsuarioModel)
                                         .ToListAsync();
        }

        public async Task<List<CargaModel>> ListarTodasCargas()
        {
            return await _context.Carga.Include(x => x.UsuarioModel)
                                         .ToListAsync();
        }
    }
}
