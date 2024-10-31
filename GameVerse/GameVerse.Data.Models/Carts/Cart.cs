﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameVerse.Data.Models.ApplicationUsers;

namespace GameVerse.Data.Models.Carts
{
    public class Cart
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public ICollection<GameCart> GamesCarts = new HashSet<GameCart>();
        public ICollection<EventCart> EventsCarts = new HashSet<EventCart>();
    }
}