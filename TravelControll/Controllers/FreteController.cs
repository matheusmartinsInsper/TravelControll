using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelControll.Models;
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
        public async Task<ActionResult<List<FreteModel>>> ListarFretesUsuario()
        {
            int idUsuario = int.Parse(Request.Query["id"]);
            List<FreteModel> fretes = await _repo.ListaFretesUsuario(idUsuario);
            return Ok(fretes);
        }
    }
}
