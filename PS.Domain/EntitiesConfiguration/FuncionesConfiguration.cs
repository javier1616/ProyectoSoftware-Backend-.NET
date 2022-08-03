using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using PS.Domain.Entities;

namespace PS.Domain.EntitiesConfiguration
{
   public class FuncionesConfiguration : IEntityTypeConfiguration<Funciones>
   {
            public void Configure(EntityTypeBuilder<Funciones> builder)
            {
                builder.HasKey(c => c.FuncionId);
                builder.Property(c => c.FuncionId)
                       .ValueGeneratedOnAdd()
                       .IsRequired(true);

                builder.Property(c => c.PeliculaId)
                       .IsRequired(true);

                builder.Property(c => c.SalaId)
                       .IsRequired(true);

                builder.Property(c => c.Fecha)
                       .IsRequired(true);

                builder.Property(c => c.Horario)
                       .IsRequired(true);

                builder.HasData(

                        new Funciones
                        {
                            FuncionId = 1,
                            PeliculaId = 1,
                            SalaId = 1,
                            Fecha = new DateTime(2008, 5, 20, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                            Horario = new TimeSpan(10, 0, 0)
                        },

                        new Funciones
                        {
                            FuncionId = 2,
                            PeliculaId = 1,
                            SalaId = 2,
                            Fecha = new DateTime(2021, 5, 20, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                            Horario = new TimeSpan(10, 0, 0)
                        },

                        new Funciones
                        {
                            FuncionId = 3,
                            PeliculaId = 1,
                            SalaId = 1,
                            Fecha = new DateTime(2021, 5, 21, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                            Horario = new TimeSpan(10, 0, 0)
                        },

                        new Funciones
                        {
                            FuncionId = 4,
                            PeliculaId = 1,
                            SalaId = 2,
                            Fecha = new DateTime(2021, 5, 20, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                            Horario = new TimeSpan(22, 0, 0)
                        }
                );

            }

   }

}