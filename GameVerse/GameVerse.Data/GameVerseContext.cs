using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data
{
    public class GameVerseContext : IdentityDbContext
    { 
        public GameVerseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
