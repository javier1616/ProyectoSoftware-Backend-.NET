using PS.Domain.Commands;
using PS.Domain.Entities;
using PS.Domain.Queries;
using System.Collections.Generic;

namespace PS.Application.Services
{
    
    public class PeliculasService : IPeliculasService
    {

        private readonly IGenericsRepository _repository;
        private readonly IPeliculasQueries _query;

        public PeliculasService(IGenericsRepository repository,IPeliculasQueries query)
        {
            _repository = repository;
            _query = query;
        }

        public PeliculasDTO GetPeliculaById(int id)
        {
            Peliculas pelicula;
            PeliculasDTO peliculaDTO;

            pelicula = _query.GetPeliculaById(id);

            if (pelicula != null)
            {
                peliculaDTO = new PeliculasDTO
                {
                    PeliculaId = pelicula.PeliculaId,
                    Titulo = pelicula.Titulo,
                    Poster = pelicula.Poster,
                    Sinopsis = pelicula.Sinopsis,
                    Trailer = pelicula.Trailer
                };

                return peliculaDTO;

            }

            return null;
           
        }

        public List<Peliculas> GetAllPeliculas()
        {
            List<Peliculas> listaDePeliculas;
            
            listaDePeliculas = _query.GetAllPeliculas();

            return listaDePeliculas;
        }

        public Peliculas UpdatePeliculas(PeliculasDTO peliculaDTO,int id)
        {

            var entity = _query.GetPeliculaById(id);

            if (entity != null)
            {
               entity.Titulo = peliculaDTO.Titulo;
               entity.Poster = peliculaDTO.Poster;
               entity.Sinopsis = peliculaDTO.Sinopsis;
               entity.Trailer = peliculaDTO.Trailer;
               
               _repository.Update<Peliculas>(entity);

            }
            return entity;
        }

    }
    
}
