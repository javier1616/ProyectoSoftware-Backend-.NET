using System.Linq;
using PS.Domain.Entities;
using PS.Domain.Queries;

namespace PS.AccessData.Queries
{
    public class SalasQueries : ISalasQueries
    { 

        private readonly TemplateDbContext _context;

        public SalasQueries(TemplateDbContext context)
        {
            _context = context;
        }

        public Salas GetSalasById(int id)
        {
            
            var salas = _context.Set<Salas>().
                                  Where(x => x.SalaId == id).First();        

            return salas;
        }

    }
}
