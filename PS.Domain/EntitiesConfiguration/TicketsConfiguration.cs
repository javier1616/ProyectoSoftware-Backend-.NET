using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain.Entities;

namespace PS.Domain.EntitiesConfiguration
{
   public class TicketsConfiguration : IEntityTypeConfiguration<Tickets>
   {
            public void Configure(EntityTypeBuilder<Tickets> builder)
            {

                builder.HasKey(c => new { c.TicketId, c.FuncionId });

                builder.Property(c => c.TicketId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.FuncionId)
                       .IsRequired(true);

                builder.Property(c => c.Usuario)
                       .HasMaxLength(50)
                       .IsRequired(true);

            }
   }
}



