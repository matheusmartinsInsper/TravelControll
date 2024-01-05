using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TravelControll.Data.ModelMapping;
using TravelControll.Models;
using Microsoft.EntityFrameworkCore.Proxies;


namespace TravelControll.Data
{
    public class TravelControllContextDb : DbContext
    {       
        public TravelControllContextDb(DbContextOptions<TravelControllContextDb> options) : base(options)
        {
        }
        public DbSet<UsuarioModel>? User { get; set; }
        public DbSet<FreteModel>? Frete { get; set; }

        public DbSet<CargaModel>? Carga { get; set; }
        public DbSet<RelatoryQuantity>? Relatorio { get; set; }
        public List<RelatoryQuantity> GerarRelatorioDeQuantidade(int id)
        {
            return Relatorio.FromSqlRaw($"SELECT * FROM reportgenerator({id})").ToList();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Habilita a carga preguiçosa
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfiguration( new MappingFrete());
            ModelBuilder.ApplyConfiguration(new MappingUsuario());
            ModelBuilder.ApplyConfiguration(new MappingVeiculo());
            ModelBuilder.ApplyConfiguration(new MappingCarga());
            ModelBuilder.ApplyConfiguration(new MappingRelatory());
        }

    }
}
