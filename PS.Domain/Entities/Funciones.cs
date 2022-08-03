using System;
using System.Collections.Generic;

namespace PS.Domain.Entities
{
    public class Funciones
    {
        public int FuncionId { get; set; }   // PK como se llama xxId (EF Core lo reconoce )
        
        //defino PeliculaId como FK            
        public int PeliculaId { get; set; }   // FK Property
        public Peliculas Pelicula { get; set; } // Reference Property

        //defino SalaId como FK            
        public int SalaId { get; set; }   // FK Property
        public Salas Sala { get; set; } // Reference Property

        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }

        
        // Tickets contiene FK de esta tabla
        public ICollection<Tickets> Tickets { get; set; }
    }
}
