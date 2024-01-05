using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public async Task<UsuarioModel> Apagar(int id) 
        {
            UsuarioModel usuarioID = await BuscarPorID(id);
            if (usuarioID != null)
            {
                _context.User.Remove(usuarioID);
                _context.SaveChanges();
                return usuarioID;
            }
            return null;
        }

        public async Task<UsuarioModel> AtualizaUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioID = await BuscarPorID(id);
            if (usuarioID != null)
            {
                Type tipoDaclasse = usuario.GetType();
                PropertyInfo[] propriedades = tipoDaclasse.GetProperties();

                foreach (PropertyInfo prop in propriedades)
                {
                    if (prop.GetValue(usuario) != null)
                    {
                        prop.SetValue(usuarioID, prop.GetValue(usuario));
                    }
                }
                _context.User.Update(usuarioID);
                _context.SaveChanges();
                return usuarioID;
            }
            return null;
        }

        public async Task<UsuarioModel> BuscarPorID(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.id_usuario == id);           
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _context.User.ToListAsync();
        }
    }
}
