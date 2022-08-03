using System;

namespace PS.Domain.Entities
{
    public class TicketsDTO
    {
        public Guid TicketId { get; set; }
        public int FuncionId { get; set; }
        public string Usuario { get; set; }

    }
}
