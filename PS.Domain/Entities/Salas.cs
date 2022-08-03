using System.Collections.Generic;

namespace PS.Domain.Entities
{
    public class Salas
    {
        public int SalaId { get; set; } // PK
        public int Capacidad { get; set; }

        // Funciones contiene una FK de esta tabla, este es el otro extremo de la relación
        public ICollection<Funciones> Funciones { get; set; }

    }
}
