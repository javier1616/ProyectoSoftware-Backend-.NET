using System.Collections.Generic;
using System.Linq;
using PS.Domain.Entities;
using PS.Domain.Queries;

namespace PS.AccessData.Queries
{
    public class TicketsQueries : ITicketsQueries
    { 

        private readonly TemplateDbContext _context;

        public TicketsQueries(TemplateDbContext context)
        {
            _context = context;
        }

        public List<Tickets> GetTicketsByFuncionId(int id)
        {

            var tickets = _context.Set<Tickets>().
                                  Where(x => x.FuncionId == id).ToList();
                                  
            return tickets;
        }

    }
}
