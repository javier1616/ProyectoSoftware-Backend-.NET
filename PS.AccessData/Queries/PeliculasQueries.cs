using System.Collections.Generic;
using System.Linq;
using PS.Domain.Entities;
using PS.Domain.Queries;

namespace PS.AccessData.Queries
{
    public class PeliculasQueries : IPeliculasQueries
    { 

        private readonly TemplateDbContext _context;

        public PeliculasQueries(TemplateDbContext context)
        {
            _context = context;
        }

        public Peliculas GetPeliculaById(int id)
        {
            Peliculas pelicula;

            
            pelicula = _context.Set<Peliculas>().
                                  Where(x => x.PeliculaId == id).SingleOrDefault();        

            return pelicula;
        }

        public List<Peliculas> GetAllPeliculas()
        {
            List<Peliculas> listaDePeliculas;

            listaDePeliculas = _context.Set<Peliculas>().ToList();

            return listaDePeliculas;
        }

    }
}
