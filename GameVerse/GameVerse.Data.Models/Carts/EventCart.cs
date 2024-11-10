using GameVerse.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Carts
{
    [PrimaryKey(nameof(EventId), nameof(CartId))]
    public class EventCart
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        [Required]
        public Guid CartId { get; set; }

        [Required]
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;

        [Required]
        public int TicketQuantity { get; set; }

        [Required]
        public  DateTime AddedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
