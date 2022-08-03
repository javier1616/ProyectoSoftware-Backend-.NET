using PS.Domain.Entities;
using System.Collections.Generic;

namespace PS.Domain.Queries
{
    public interface IPeliculasQueries
    {
        Peliculas GetPeliculaById(int id);
        List<Peliculas> GetAllPeliculas();
    }
}
