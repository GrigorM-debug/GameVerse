
using GameVerse.Data.Models.Events;

namespace GameVerse.Data.Models
{
    public class EventCart
    {
        public Guid CartId { get; set; }

        public Cart Cart { get; set; } = null!;

        public Guid EventId { get; set; }

        public Event Event { get; set; } = null!;

        public int TicketQuantity { get; set; }

        public decimal Price { get; set; }
    }
}
