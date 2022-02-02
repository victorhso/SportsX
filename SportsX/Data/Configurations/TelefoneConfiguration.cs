using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Entities;

namespace SportsX.Data.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("TELEFONE");
            builder.HasKey(p => p.ID_TELEFONE);
            builder.Property(p => p.NR_TELEFONE).HasMaxLength(15);
            builder.Property(p => p.ID_PF).HasColumnType("INT");
            builder.Property(p => p.ID_PJ).HasColumnType("INT");
        }
    }
}
