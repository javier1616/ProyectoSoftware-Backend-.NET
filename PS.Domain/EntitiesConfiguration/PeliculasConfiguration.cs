using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain.Entities;

namespace PS.Domain.EntitiesConfiguration
{
    
    public class PeliculasConfiguration : IEntityTypeConfiguration<Peliculas>
    {
            public void Configure(EntityTypeBuilder<Peliculas> builder)
            {
                builder.HasKey(c => c.PeliculaId);
                builder.Property(c => c.PeliculaId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Titulo)
                       .IsRequired(true)
                       .HasMaxLength(50);

                builder.Property(c => c.Poster)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.Property(c => c.Sinopsis)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.Property(c => c.Trailer)
                       .IsRequired(true)
                       .HasMaxLength(255);

                builder.HasData(
  
                   new Peliculas {
                       PeliculaId = 1,
                       Titulo = "Jurassic Park",
                       Poster = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX667_.jpg",
                       Sinopsis = "Un paleontólogo pragmático que visita un parque temático casi completo tiene la tarea de proteger a un par de niños después de que un corte de energía provoque que los dinosaurios clonados del parque se suelten.",
                       Trailer = "https://www.youtube.com/embed/lc0UehYemQA"
                   },

                   new Peliculas
                   {
                       PeliculaId = 2,
                       Titulo = "Indiana Jones and the Last Crusade",
                       Poster = "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_FMjpg_UY720_.jpg",
                       Sinopsis = "En 1938, después de la desaparición de su padre el profesor Henry Jones Senior en su búsqueda del Santo Grial, Indiana Jones se enfrenta de nuevo a los Nazis para que evitar que obtengan sus poderes.",
                       Trailer = "https://www.youtube.com/embed/sagmdpkWUqc"
                   },

                   new Peliculas
                   {
                       PeliculaId = 3,
                       Titulo = "Gremlins",
                       Poster = "https://m.media-amazon.com/images/M/MV5BZDVjN2FkYTQtNTBlOC00MjM5LTgzMWEtZWRlNGUyYmNiOTFiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX467_.jpg",
                       Sinopsis = "Un niño rompe inadvertidamente tres reglas importantes sobre su nueva mascota y provoca una horda de monstruos malévolos y traviesos en una pequeña ciudad.",
                       Trailer = "https://www.youtube.com/embed/XBEVwaJEgaA"
                   },

                   new Peliculas
                   {
                       PeliculaId = 4,
                       Titulo = "Back to the Future",
                       Poster = "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX1218_.jpg",
                       Sinopsis = "Marty McFly, un estudiante de secundaria de 17 años, es enviado accidentalmente treinta años atrás en un DeLorean que viaja en el tiempo inventado por su amigo íntimo, el científico disidente Doc Brown.",
                       Trailer = "https://www.youtube.com/embed/qvsgGtivCgs"
                   },

                   new Peliculas
                   {
                       PeliculaId = 5,
                       Titulo = "Clockwork Orange",
                       Poster = "https://m.media-amazon.com/images/M/MV5BMTY3MjM1Mzc4N15BMl5BanBnXkFtZTgwODM0NzAxMDE@._V1_FMjpg_UX878_.jpg",
                       Sinopsis = "En el futuro, el sádico líder de una banda es encarcelado y se ofrece como voluntario para un experimento de reeducación, pero no sale según lo planeado.",
                       Trailer = "https://www.youtube.com/embed/T54uZPI4Z8A"
                   },

                   new Peliculas
                   {
                       PeliculaId = 6,
                       Titulo = "Attack of the Killer Tomatoes!",
                       Poster = "https://m.media-amazon.com/images/M/MV5BZWMxOTEzMjktYjE3NC00NmZjLThlNzYtMDE3MDlmNWVmZTZkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX871_.jpg",
                       Sinopsis = "Los tomates, hartos de tantos años de acabar como sofrito o bloody mary, están cobrando vida y están asesinando a los humanos. Se sospecha que este hecho está provocado por un pesticida creado por un loco que quiere el control del mundo.",
                       Trailer = "https://www.youtube.com/embed/txfdGlxEsG8"
                   },

                   new Peliculas
                   {
                       PeliculaId = 7,
                       Titulo = "Beetlejuice",
                       Poster = "https://m.media-amazon.com/images/M/MV5BZDdmNjBlYTctNWU0MC00ODQxLWEzNDQtZGY1NmRhYjNmNDczXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX1005_.jpg",
                       Sinopsis = "Un matrimonio recientemente fallecido le encarga a un extraño demonio que saque a una insoportable familia de su hogar.",
                       Trailer = "https://www.youtube.com/embed/ickbVzajrk0"
                   },

                   new Peliculas
                   {
                       PeliculaId = 8,
                       Titulo = "Rocky",
                       Poster = "https://m.media-amazon.com/images/M/MV5BMTY5MDMzODUyOF5BMl5BanBnXkFtZTcwMTQ3NTMyNA@@._V1_FMjpg_UX682_.jpg",
                       Sinopsis = "Un boxeador poco conocido tiene la gran oportunidad de enfrentarse al campeón de los pesos pesados en un combate en el que espera estar a la altura y hacerse un nombre.",
                       Trailer = "https://www.youtube.com/embed/7RYpJAUMo2M"
                   },

                   new Peliculas
                   {
                       PeliculaId = 9,
                       Titulo = "Star Wars",
                       Poster = "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UY745_.jpg",
                       Sinopsis = "Luke Skywalker une sus fuerzas con un caballero jedi, un piloto fanfarrón, un wookiee y dos droides para salvar a la galaxia de la estación espacial del Imperio, a la vez que intenta rescatar a la princesa Leia del malvado Darth Vader.",
                       Trailer = "https://www.youtube.com/embed/vZ734NWnAHA"
                   },

                   new Peliculas
                   {
                       PeliculaId = 10,
                       Titulo = "Alien",
                       Poster = "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UY720_.jpg",
                       Sinopsis = "Un buque espacial percibe una transmisión desconocida pidiendo ayuda. Al llegar al origen de la señal encuentran a uno de los tripulantes atacado por una misteriosa forma de vida. Pronto se dan cuenta de que su ciclo vital acaba de empezar.",
                       Trailer = "https://www.youtube.com/embed/LjLamj-b0I8"
                   }

                );  


            }
        
    }

}
