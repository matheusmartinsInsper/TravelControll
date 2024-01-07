using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelControll.Models;
using TravelControll.Repositories;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepositorio _repoVeiculo;
        public VeiculoController(IVeiculoRepositorio repoVeiculo)
        {
            _repoVeiculo = repoVeiculo;
        }
        [HttpGet]
        public async Task<ActionResult<Response<List<VeiculoModel>>>> ListarTodosVeiculos()
        {
            Response<List<VeiculoModel>> resposta = new Response<List<VeiculoModel>>()
            {
                status = "Ok",
                message = "Veiculos Disponiveis",
                data = null
            };
            try
            {
               List<VeiculoModel> veiculos = await _repoVeiculo.ListarTodosVeiculos();
               resposta.data=veiculos;
               return Ok(resposta);
            }
            catch (DbUpdateException ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpGet("usuario")]
        public async Task<ActionResult<Response<List<VeiculoModel>>>> ListarVeiculosUsuario()
        {
            Response<List<VeiculoModel>> resposta = new Response<List<VeiculoModel>>()
            {
                status = "Ok",
                message = "Veiculos Disponiveis",
                data = null
            };
            try
            {
                int idUsuario = int.Parse(Request.Query["id"]);
                List<VeiculoModel> veiculos = await _repoVeiculo.ListarVeiculosUsuario(idUsuario);
                resposta.data = veiculos;
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
        public async Task<ActionResult<Response<VeiculoModel>>> AdicionarVeiculo([FromBody] VeiculoModel veiculo)
        {
            Response<VeiculoModel> resposta = new Response<VeiculoModel>()
            {
                status = "Ok",
                message = "Veiculo Postado com Sucesso",
                data = null
            };
            try
            {
                VeiculoModel veiculoPostado = await _repoVeiculo.AdicionarVeiculo(veiculo);
                resposta.data = veiculoPostado;
                return Ok(resposta);
            }
            catch (DbUpdateException ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Response<VeiculoModel>>> DeletarVeiculo()
        {
            Response<VeiculoModel> resposta = new Response<VeiculoModel>()
            {
                status = "Ok",
                message = "Veiculo Deletado com Sucesso",
                data = null
            };
            try
            {
                int idVeiculo = int.Parse(Request.Query["idFrete"]);
                VeiculoModel veiculoDeletado=await _repoVeiculo.Apagar(idVeiculo);
                if (veiculoDeletado == null)
                {
                    resposta.message = "Veiculo não cadastrado";
                }
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
        public async Task<ActionResult<Response<VeiculoModel>>> AtualizarVeiculo(VeiculoModel veiculo)
        {
            Response<VeiculoModel> resposta = new Response<VeiculoModel>()
            {
                status = "Ok",
                message = "Veiculo Atualizado com Sucesso",
                data = null
            };
            try
            {
                int idVeiculo = int.Parse(Request.Query["idFrete"]);
                VeiculoModel veiculoAtualizado=await _repoVeiculo.AtualizarVeiculo(veiculo, idVeiculo);
                resposta.data = veiculoAtualizado;
                return Ok(resposta);
            }
            catch (DbUpdateException ex)
            {
                resposta.status = "error";
                resposta.message = new HandlerError().handlerErroMesage(ex);
                return BadRequest(resposta);
            }
        }
    }
}
