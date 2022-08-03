using System.Collections.Generic;

namespace PS.Domain.Entities
{
    public class Peliculas
    {
        public int PeliculaId { get; set; } // PK
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }

        // Funciones contiene una FK de esta tabla, este es el otro extremo de la relación
        public ICollection<Funciones> Funciones { get; set; }

    }
}
