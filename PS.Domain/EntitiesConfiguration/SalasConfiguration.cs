using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain.Entities;

namespace PS.Domain.EntitiesConfiguration
{
    
    public class SalasConfiguration : IEntityTypeConfiguration<Salas>
    {
        public void Configure(EntityTypeBuilder<Salas> builder)
        {
            builder.HasKey(c => c.SalaId);
            builder.Property(c => c.SalaId)
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(c => c.Capacidad)
                .IsRequired(true);

            builder.HasData(

                   new Salas { SalaId = 1, Capacidad = 5 },
                   new Salas { SalaId = 2, Capacidad = 15},
                   new Salas { SalaId = 3, Capacidad = 35}
                   
            );  


        }
        
    }

}
