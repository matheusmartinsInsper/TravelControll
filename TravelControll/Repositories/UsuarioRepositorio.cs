using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TravelControll.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TravelControllContextDb _context;
        public UsuarioRepositorio(TravelControllContextDb context)
        {
            _context = context;
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            
            await _context.User.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public Task<bool> Apagar(int id) 
        {
            throw new NotImplementedException();
            _context.SaveChanges(); 
        }

        public async Task<UsuarioModel> AtualizaUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioID = await BuscarPorID(id);
            
            usuarioID.nome = usuario.nome;
            usuarioID.email = usuario.email;
            _context.User.Update(usuarioID);
            _context.SaveChanges();
            return usuarioID;
        }

        public async Task<UsuarioModel> BuscarPorID(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.id_usuario == id);
            
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _context.User.Include(u=>u.fretes).ToListAsync();
        }
    }
}
