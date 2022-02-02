using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Entity;

namespace SportsX.Data.Configurations
{
    public class PFisicaConfiguration : IEntityTypeConfiguration<PFisica>
    {
        public void Configure(EntityTypeBuilder<PFisica> builder)
        {
            builder.ToTable("PFISICA");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.DS_NOME).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DS_EMAIL).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.NR_CPF).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(p => p.DS_CLASSIFICACAO).HasColumnType("BIT").IsRequired();

            //builder.HasOne(p => p.Endereco).WithOne(e => e.PFisica);
            //builder.HasMany(p => p.Telefones).WithOne(e => e.PFisica);
        }
    }
}
