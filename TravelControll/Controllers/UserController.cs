using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelControll.Models;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repoUser;
        public UserController(IUsuarioRepositorio repo)
        {
            _repoUser = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> users = await _repoUser.BuscarTodosUsuarios();
            
            return Ok(users);

        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuario)
        {
            
                UsuarioModel user = await _repoUser.AdicionarUsuario(usuario);
                return Ok(user);
            
        }
        [HttpGet("especifico")]

        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioEspecífico()
        {
            int idUsuario = int.Parse(Request.Query["id"]);
            UsuarioModel user = await _repoUser.BuscarPorID(idUsuario);
            return Ok(user);
        }
    }
}
