using Microsoft.EntityFrameworkCore;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Repositories;
using TravelControll.Repositories.Interfaces;
using TravelControll.Services;
using TravelControll.Services.Interfaces;

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
                options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );
            //Configurando injeção de dependencia
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IFreteRepositorio, FreteRepositorio>();
            builder.Services.AddScoped <IRelatory<RelatoryQuantity>, GeneratorRelatoryQuantity>();

            var app = builder.Build();

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