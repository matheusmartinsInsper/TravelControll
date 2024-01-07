using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelControll.Models;
using TravelControll.Services.EmailService;
using TravelControll.Services.RelatoryService.Interfaces;

namespace TravelControll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoryController:ControllerBase
    {
        //public readonly IRelatory<RelatoryQuantity> _repo;
        //public RelatoryController(IRelatory<RelatoryQuantity> repo)
        //{
        //    _repo = repo;
        //}
        //[HttpGet]
        //public async Task<ActionResult<String>> GerarRelatorio()
        //{
        //    int idUser = int.Parse(Request.Query["id"]);
        //    //_repo.GerarRelatorio(idUser);
        //    return Ok("Relatorio Gerado");
        //}
        //[HttpPost]
        //public async Task<ActionResult<String>> EnviarRelatorioPorEmail()
        //{
        //    DotNetEnv.Env.Load();
        //    string password = Environment.GetEnvironmentVariable("PASSWORD");
        //    string username = Environment.GetEnvironmentVariable("USERNAME");
        //    var outlook = new Email("smtp.office365.com", username, password);
        //    outlook.SendEmail(
        //        emailsTo: new List<string>
        //        {
        //            "mateusrochaprime690@gmail.com"
        //        },
        //        subject: "testando",
        //        body: "my first email",
        //        attachments: new List<string>
        //        {
        //            @"C:\Users\User\RelatoriosTravelControll\firstRelatory.xlsx"
        //        }
        //        );
        //    return Ok("Relatorio enviado por email");
        //}
    }
}
