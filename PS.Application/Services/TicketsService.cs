using System.Collections.Generic;
using PS.Domain.Commands;
using PS.Domain.Entities;
using PS.Domain.Queries;

namespace PS.Application.Services
{
    public class TicketsService : ITicketsService
    {

        private readonly IGenericsRepository _repository;
        private readonly ITicketsQueries _query;
        private readonly IFuncionesQueries _queryF;
        private readonly ISalasQueries _queryS;

        public TicketsService(IGenericsRepository repository,ITicketsQueries query,IFuncionesQueries queryF,ISalasQueries queryS)
        {
            _repository = repository;
            _query = query;
            _queryF = queryF;
            _queryS = queryS;
        }

        public List<Tickets> GetTicketsByFuncionId(int id)
        {
          
            var tickets = _query.GetTicketsByFuncionId(id);

            return tickets;
           
        }

        public List<TicketsDTO> CreateTickets(TicketConCantidad ticketConCantidad)
        {
        
            int ticketsVendidos;
            var listaDeTicketsGenerados = new List<Tickets>();
            var listaDeTicketsGeneradosDTO = new List<TicketsDTO>();

            if (ticketConCantidad.Cantidad > 0 && ticketConCantidad.Usuario.Length <=50)
            {

                var funcion = _queryF.GetFuncionesById(ticketConCantidad.FuncionId);

                if (funcion != null)
                {
                    var sala = _queryS.GetSalasById(funcion.SalaId);
                    var listaDeTickets = _query.GetTicketsByFuncionId(ticketConCantidad.FuncionId);

                    ticketsVendidos = listaDeTickets.Count;

                    if ((ticketsVendidos + ticketConCantidad.Cantidad) <= sala.Capacidad)
                    {

                        for (int i = 0; i < ticketConCantidad.Cantidad; i++)
                        {
                            var entity = new Tickets
                            {
                                FuncionId = ticketConCantidad.FuncionId,
                                Usuario = ticketConCantidad.Usuario
                            };

                            _repository.Add<Tickets>(entity);

                            listaDeTicketsGenerados.Add(entity);

                        }

                    }

                }

            }

            foreach (Tickets elem in listaDeTicketsGenerados)
            {
                TicketsDTO ticketDTO = new TicketsDTO
                {
                    TicketId = elem.TicketId,
                    FuncionId = elem.FuncionId,
                    Usuario = elem.Usuario
                };

                listaDeTicketsGeneradosDTO.Add(ticketDTO);
            
            }

            return listaDeTicketsGeneradosDTO;
            
        }

    }
    
}
