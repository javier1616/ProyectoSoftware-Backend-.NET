using System.Collections.Generic;
using PS.Domain.Entities;

namespace PS.Application.Services
{
    public interface ITicketsService
    {
        List<Tickets> GetTicketsByFuncionId(int id);
        List<TicketsDTO> CreateTickets(TicketConCantidad ticketConCantidad);
    }
}
