using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Entity;

namespace SportsX.Data.Configurations
{
    public class PJuridicaConfiguration : IEntityTypeConfiguration<PJuridica>
    {
        public void Configure(EntityTypeBuilder<PJuridica> builder)
        {
            builder.ToTable("PJURIDICA");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.DS_RAZAO_SOCIAL).HasMaxLength(100).IsRequired();
            builder.Property(p => p.DS_EMAIL).HasMaxLength(100).IsRequired();
            builder.Property(p => p.NR_CNPJ).HasMaxLength(14).IsRequired();
            builder.Property(p => p.DS_CLASSIFICACAO).HasColumnType("BIT").IsRequired();

            //builder.HasOne(p => p.Endereco).WithOne(e => e.PJuridica);
            //builder.HasMany(p => p.Telefones).WithOne(e => e.PJuridica);
        }
    }
}
