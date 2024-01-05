using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TravelControll.Models;
using TravelControll.Repositories;
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
        public async Task<ActionResult<Response<List<UsuarioModel>>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> users = await _repoUser.BuscarTodosUsuarios();
            Response<List<UsuarioModel>> resposta = new Response<List<UsuarioModel>>()
            {
                status = "ok",
                message = "Usuarios ativo",
                data = users
            };
            return Ok(resposta);
        }
        [HttpPost]
        public async Task<ActionResult<Response<UsuarioModel>>> AdicionarUsuario([FromBody] UsuarioModel usuario)
        {
            Response<UsuarioModel> resposta = new Response<UsuarioModel>()
            {
                status = "ok",
                message = "Usuario ativo",
                data = null
            };
            try
            {
                UsuarioModel user = await _repoUser.AdicionarUsuario(usuario);
                resposta.data = user;
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }  
        }
        [HttpGet("especifico")]
        public async Task<ActionResult<Response<UsuarioModel>>> BuscarUsuarioEspecífico()
        {
            Response<UsuarioModel> resposta = new Response<UsuarioModel>()
            {
                status = "ok",
                message = "Usuario ativo",
                data = null
            };
            try
            {
                int idUsuario = int.Parse(Request.Query["id"]);
                UsuarioModel user = await _repoUser.BuscarPorID(idUsuario);
                resposta.data = user;
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Response<UsuarioModel>>> AtualizarUsuario([FromBody] UsuarioModel usuario)
        {
            Response<UsuarioModel> resposta = new Response<UsuarioModel>()
            {
                status = "ok",
                message = "Usuario Atualizado",
                data = null
            };
            try
            {
                int idUsuario = int.Parse(Request.Query["id"]);
                UsuarioModel usuarioAtualizado = await _repoUser.AtualizaUsuario(usuario, idUsuario);
                resposta.data = usuarioAtualizado;
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Response<UsuarioModel>>> DeletarUsuario()
        {
            Response<UsuarioModel> resposta = new Response<UsuarioModel>()
            {
                status= "ok",
                message= "Usuario deletado",
                data = null
            };
            try
            {
                int idUsuario = int.Parse(Request.Query["id"]);
                UsuarioModel deletUsuerBool = await _repoUser.Apagar(idUsuario);
                if (deletUsuerBool == null)
                {
                    resposta.message = "Usuario nao encontrado";
                }
                resposta.data = deletUsuerBool;
                return Ok(resposta);
            }
            catch(Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
    }
}
