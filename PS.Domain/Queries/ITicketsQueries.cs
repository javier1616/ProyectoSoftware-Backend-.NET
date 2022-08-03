using System.Collections.Generic;
using PS.Domain.Entities;

namespace PS.Domain.Queries
{
    public interface ITicketsQueries
    {
        List<Tickets> GetTicketsByFuncionId(int id);
        
    }
}
