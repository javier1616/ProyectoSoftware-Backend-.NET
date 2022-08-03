using Microsoft.AspNetCore.Mvc;
using PS.Application.Services;
using PS.Domain.Entities;

namespace TP2_Cine.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketsService _service;
        public TicketsController(ITicketsService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult PostTickets([FromBody] TicketConCantidad ticketConCantidad)
        {

            var listaDeTicketsGenerados = _service.CreateTickets(ticketConCantidad);

            
            if (listaDeTicketsGenerados.Count > 0)
            {
                return StatusCode(201,listaDeTicketsGenerados);
            }
            else
            {
                return StatusCode(400);
            }

        }

    }   
}
