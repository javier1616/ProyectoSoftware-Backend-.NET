using Microsoft.AspNetCore.Mvc;
using PS.Application.Services;
using PS.Domain.Entities;
using System.Collections.Generic;

namespace TP2_Cine.Controllers
{
    [Route("api/pelicula")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        private readonly IPeliculasService _service;
        
        public PeliculasController(IPeliculasService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPeliculasById(int id)
        {
            
            PeliculasDTO pelicula;

            pelicula = _service.GetPeliculaById(id);

            if (pelicula != null)
            {
                return Ok(pelicula);
            }
            else
            {
                return StatusCode(404);
            }

        }

        [HttpGet()]
        public IActionResult GetAllPeliculas()
        {

            List<Peliculas> listaDePeliculas;

            listaDePeliculas = _service.GetAllPeliculas();

            if (listaDePeliculas != null)
            {
                return Ok(listaDePeliculas);
            }
            else
            {
                return StatusCode(404);
            }

        }

        [HttpPut("{id:int}")]
        public IActionResult PutPelicula(int id,[FromBody] PeliculasDTO peliculaDTO)
        {

            var peliculaModificada = _service.UpdatePeliculas(peliculaDTO, id);
               
            if ( peliculaModificada != null )
            {
               return Ok(peliculaModificada);
            }
            else
            {
               return StatusCode(404);
            }
            
        }

    }   
}
