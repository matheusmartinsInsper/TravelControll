using Microsoft.AspNetCore.Mvc;
using TravelControll.Models;
using TravelControll.Services.Interfaces;

namespace TravelControll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoryController:ControllerBase
    {
        public readonly IRelatory<RelatoryQuantity> _repo;
        public RelatoryController(IRelatory<RelatoryQuantity> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<String>> GerarRelatorio()
        {
            int idUser = int.Parse(Request.Query["id"]);
            _repo.GerarRelatorio(idUser);
            return Ok("Relatorio Gerado");
        }
    }
}
