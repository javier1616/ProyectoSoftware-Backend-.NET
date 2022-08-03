using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PS.Application.Services;
using System;
using PS.Domain.EntitiesDTO;
using System.Text.Json;

namespace TP2_Cine.Controllers
{
    [Route("api/funcion")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {

        private readonly IFuncionesService _service;
   
        public FuncionesController(IFuncionesService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public IActionResult GetFuncionesByDateOrTitle( [FromQuery(Name ="Fecha")] string fecha,
                                                          [FromQuery(Name = "Título")] string titulo)
        {

            List<FuncionesDTO> funciones;
            DateTime fechaConFormato;

            if (fecha == null)
            {
                fechaConFormato = DateTime.Today;
            } 
            else if (!DateTime.TryParse(fecha, out fechaConFormato))
            {
                return StatusCode(400);
            }
            

            if (titulo == null)
            {
                funciones = _service.GetFuncionesByDate(fechaConFormato);
            }
            else if (titulo.Length <= 50)
            {
                funciones = _service.GetFuncionesByDateAndTitle(fechaConFormato, titulo);
            }
            else return StatusCode(400);

            if (funciones.Count > 0)
            {
                return StatusCode(200,funciones);
            }
            else
            {
                return StatusCode(404);
            }

        }

        
        [HttpPost]
        public IActionResult PostFuncion([FromBody] FuncionesDTOFechaHoraString funcionFechaHoraString)
        {

              var nuevaFuncion = _service.CreateFuncion(funcionFechaHoraString);

              if (nuevaFuncion != null)
              {
                  return StatusCode(201,nuevaFuncion);
              }
              else
              {
                  return StatusCode(400);
              } 

        }

        [HttpGet("pelicula/{id:int}")]        
        public IActionResult GetAllFuncionesByPeliculaId(int id)       
        {

             var listaDeFunciones = _service.GetAllFuncionesByPeliculaId(id);


             if (listaDeFunciones != null)
             {
                 return Ok(listaDeFunciones);
             }
             else
             {
                 return StatusCode(404);
             }

        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteFuncionesById(int id)
        {
           if(_service.RemoveFunciones(id))
           {
                return StatusCode(200);
           }
           else
           {
                return StatusCode(404);
           }

        }

        [HttpGet("{id:int}/tickets")]
        public IActionResult GetTicketsDisponiblesByFuncionId(int id)
        {

            var cantidadDeTicketsDisponibles = _service.GetTicketsDisponiblesByFuncionId(id);

            var tickets = new 
            {
                tickets = cantidadDeTicketsDisponibles,
            };


            if (cantidadDeTicketsDisponibles > -1)
            {
                //return Ok(cantidadDeTicketsDisponibles);
                return Ok(JsonSerializer.Serialize(tickets));
            }
            else  
            {
                cantidadDeTicketsDisponibles = 0;
                return StatusCode(404, JsonSerializer.Serialize(tickets));
            }

        }

    }   
}
