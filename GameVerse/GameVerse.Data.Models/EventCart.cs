
using GameVerse.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models
{
    [PrimaryKey(nameof(EventId), nameof(CartId))]
    public class EventCart
    {
        public Guid EventId { get; set; }

        [Required]
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        public Guid CartId { get; set; }

        [Required]
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;

        public int TicketQuantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
