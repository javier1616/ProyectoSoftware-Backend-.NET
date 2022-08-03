using System;

namespace PS.Domain.EntitiesDTO
{
    public class FuncionesDTO
    { 
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }  
        public int SalaId { get; set; }   
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }

    }
}
