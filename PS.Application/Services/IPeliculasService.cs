using PS.Domain.Entities;
using System.Collections.Generic;

namespace PS.Application.Services
{
    public interface IPeliculasService
    {
        PeliculasDTO GetPeliculaById(int id);
        Peliculas UpdatePeliculas(PeliculasDTO peliculaDTO, int id);
        List<Peliculas> GetAllPeliculas();
    }

    

}
