﻿using Microsoft.EntityFrameworkCore;
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
        
        public DbSet<FreteModel> Fretes { get; set ; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Habilita a carga preguiçosa
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfiguration( new MappingFrete());
            ModelBuilder.ApplyConfiguration(new MappingUsuario());
            
        }

    }
}
