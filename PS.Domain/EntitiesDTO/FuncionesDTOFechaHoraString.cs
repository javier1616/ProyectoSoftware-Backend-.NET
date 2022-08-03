using PS.Domain.Entities;
using System;

namespace PS.Domain.EntitiesDTO
{
    public class FuncionesDTOFechaHoraString
    { 
        public int PeliculaId { get; set; }  
        public int SalaId { get; set; }   
        public string Fecha { get; set; }
        public string Horario { get; set; }

    }
}
