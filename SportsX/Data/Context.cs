using Microsoft.EntityFrameworkCore;
using SportsX.Entities;
using SportsX.Entity;
using System;
using System.Linq;

namespace SportsX.Data
{
    public class Context : DbContext
    {
        public DbSet<PFisica> PFisica { get; set; }
        public DbSet<PJuridica> PJuridica { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone  { get; set; }

        //Onde se configura a string de conexão com o BD.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Informar qual provider se está utilizando (SQL Server/ MySQL, NoSQL ...)
			
			// ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Aqui o nome do banco ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ (substituir DEV-VICTOR)
			
            optionsBuilder
                .UseSqlServer("Data source=DEV-VICTOR;Initial Catalog=SportsX;Integrated Security=true", p => p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null).MigrationsHistoryTable("SportsX"));
        }
        //Configurando modelo de Dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplica a configuração de todas as IEntityTypeConfiguration<TEntity> instâncias definidas no assembly fornecido.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            MapearPropriedadesEquecidas(modelBuilder);
        }

        private void MapearPropriedadesEquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        //property.SetMaxLength(100); Ou
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
