using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories;
using TravelControll.Repositories.Interfaces;
using TravelControll.Services.EmailService;
using TravelControll.Services.RelatoryService;
using TravelControll.Services.RelatoryService.Interfaces;

namespace TravelControll.Routine
{
    public class BackgroundRelatoryGenerator
    {
        //private readonly IRelatory<RelatoryQuantity> _relatory;
        private readonly IServiceScopeFactory _scopeFactory;
        public BackgroundRelatoryGenerator(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async void RelatoryGeneratorSendEmail(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var generatorRelatory = scope.ServiceProvider.GetRequiredService<IRelatory<RelatoryQuantity>>();

                string date = DateTime.Now.ToString("yyyy-MM-dd");
                DotNetEnv.Env.Load();
                string password = Environment.GetEnvironmentVariable("PASSWORD");
                string username = Environment.GetEnvironmentVariable("USERNAME");
                List<UsuarioModel> users = await generatorRelatory.UsuariosRelatorio();

                foreach (UsuarioModel user in users)
                {
                    int idUser = user.id_usuario ?? throw new Exception();
                    generatorRelatory.GerarRelatorio(idUser, date);
                }

                Console.WriteLine($"testando background function and {username} on date: {date}");

                Email outlook = new Email("smtp.office365.com", username, password);
                outlook.SendEmail(
                emailsTo: new List<string>
                {
                "mateusrochaprime690@gmail.com",
                "Netovieira008@gmail.com",
                "netosantosvieira009@gmail.com"
                },
                subject: $"Relatorio status fretes do dia {date}",
                body: "Olá Matheus, segue em anexo o seu relatorio de fretes e suas respectivas quantidades",
                attachments: new List<string>
                {
                  @"C:\Users\User\RelatoriosTravelControll\firstRelatory.xlsx"
                }
                );
                // Outras operações...
            } 
        }
    }
}
