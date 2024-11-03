

using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Services
{
    public class ModeratorService(IGenericRepository<Moderator, Guid> moderatorRepository) : IModeratorService
    {
        private readonly IGenericRepository<Moderator, Guid> _moderatorRepository = moderatorRepository;

        public async Task<string?> GetModeratorIdByUserIdAsync(string? userId)
        {
            Moderator? moderator = await _moderatorRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return null;
            }

            return moderator.Id.ToString();
        }

        public async Task<bool> ModeratorExistByUserIdAsync(string userId)
        {
            Moderator? moderator = await _moderatorRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return false;
            }

            return true;
        }
    }
}
