using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories;
using TravelControll.Repositories.Interfaces;
using TravelControll.Routine;
using TravelControll.Services.RelatoryService;
using TravelControll.Services.RelatoryService.Interfaces;

namespace TravelControll
{
    public class Program
    {
        public static void Main(string[] args)
        {        

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Configurando a conexao com o banco de dados 
            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<TravelControllContextDb>(
                options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")),
                ServiceLifetime.Scoped
                );
            //Configurando injeção de dependencia
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IFreteRepositorio, FreteRepositorio>();
            builder.Services.AddScoped<IRelatory<RelatoryQuantity>, GeneratorRelatoryQuantity>();
            builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            builder.Services.AddSingleton<BackgroundRelatoryGenerator>();

            //var serviceProvider = new ServiceCollection()
            //.BuildServiceProvider();
            var app = builder.Build();

            BackgroundRelatoryGenerator backgroundrelatory = app.Services.GetRequiredService<BackgroundRelatoryGenerator>();
            DateTime horaDesejada = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 06, 0, 0);
            TimeSpan tempoAteProximaExecucao = horaDesejada > DateTime.Now
            ? horaDesejada - DateTime.Now
            : horaDesejada.AddDays(1) - DateTime.Now;
            TimerCallback timerCallback = async state =>
            {
                await Task.Run(() => backgroundrelatory.RelatoryGeneratorSendEmail(state));
            };
            Timer timer = new Timer(timerCallback, null, tempoAteProximaExecucao, TimeSpan.FromDays(1));

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}