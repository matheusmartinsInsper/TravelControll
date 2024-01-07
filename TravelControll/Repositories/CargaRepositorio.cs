using Microsoft.EntityFrameworkCore;
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

        public Task<CargaModel> AtualizarCarga(CargaModel carga, int IdCarga)
        {
            throw new NotImplementedException();
        }

        public Task<CargaModel> BuscarCargaPorId(int IdCarga)
        {
            return _context.Carga.FirstOrDefaultAsync(x => x.id == IdCarga);
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
