using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Entity;

namespace SportsX.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(p => p.ID_ENDERECO);
            builder.Property(p => p.NR_CEP).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ID_PF).HasColumnType("INT");
            builder.Property(p => p.ID_PJ).HasColumnType("INT");
        }
    }
}
