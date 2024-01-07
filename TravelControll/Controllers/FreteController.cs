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
    public class FreteController : ControllerBase
    {
        private readonly IFreteRepositorio _repo;
        public FreteController(IFreteRepositorio repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<Response<List<FreteModel>>>> ListarFretes()
        {
            Response<List<FreteModel>> resposta = new Response<List<FreteModel>>()
            {
                status = "Ok",
                message = "Fretes disponiveis",
                data = null
            };
            try
            {
                List<FreteModel> fretes = await _repo.ListaFretes();
                resposta.data= fretes;
                return Ok(resposta);
            }
            catch(Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpGet("usuario")]
        public async Task<ActionResult<Response<List<FreteModel>>>> ListarFretesUsuario()
        {
            Response<List<FreteModel>> resposta = new Response<List<FreteModel>>()
            {
                status = "Ok",
                message = "Fretes disponiveis",
                data = null
            };
            try
            {
                int idUsuario = int.Parse(Request.Query["id"]);
                List<FreteModel> fretes = await _repo.ListaFretesUsuario(idUsuario);
                resposta.data = fretes;
                return Ok(resposta);
            }
            catch (DbUpdateException ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Response<FreteModel>>> AtualizarFrete([FromBody] FreteModel frete)
        {
            Response<FreteModel> resposta = new Response<FreteModel>()
            {
                status = "ok",
                message = "Frete atualizado",
                data = null
            };
            try
            {
                int idFrete = int.Parse(Request.Query["id"]);
                FreteModel freteAtualizado = await _repo.AtualizaFrete(frete,idFrete);
                resposta.data = freteAtualizado;
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpPut("aceito")]
        public async Task<ActionResult<Response<FreteModel>>> AtualizarFreteAceito([FromBody] FreteModel frete)
        {
            Response<FreteModel> resposta = new Response<FreteModel>()
            {
                status = "ok",
                message = "Frete aceito com sucesso",
                data = null
            };
            try
            {
                int idFrete = int.Parse(Request.Query["id"]);
                FreteModel freteAtualizado = await _repo.AtualizaFreteAceito(frete,idFrete);
                resposta.data = freteAtualizado;
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
        public async Task<ActionResult<Response<FreteModel>>> ApagarFrete()
        {
            Response<FreteModel> resposta = new Response<FreteModel>()
            {
                status = "Ok",
                message = "Frete deletado com sucesso",
                data = null
            };
            try
            {
                int idFrete = int.Parse(Request.Query["idFrete"]);
                var resp = await _repo.DeletarFrete(idFrete);
                return Ok(resposta);
            }
            catch (DbUpdateException ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Response<FreteModel>>> AdicionarFrete([FromBody] FreteModel Frete)
        {
            Response<FreteModel> resposta = new Response<FreteModel>()
            {
                status = "Ok",
                message = "Frete adicionado com sucesso",
                data = null
            };
            try
            {
                FreteModel frete = await _repo.AdicionarFrete(Frete);
                resposta.data = frete;
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
