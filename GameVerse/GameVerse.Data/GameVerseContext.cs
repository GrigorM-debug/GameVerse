﻿using GameVerse.Data.Models;
using GameVerse.Data.Models.Games;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data
{
    public class GameVerseContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    { 
        public GameVerseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Game>()
                .Property(g => g.Type)
                .HasConversion<string>(); // Convert Enum to string in the Database. 

            base.OnModelCreating(builder);
        }
    }
}
