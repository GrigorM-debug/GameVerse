

using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;

namespace GameVerse.Services
{
    public class ModeratorService(IGenericRepository<Moderator, Guid> moderatorRepository) : IModeratorService
    {
        private readonly IGenericRepository<Moderator, Guid> _moderatorRepository = moderatorRepository;

        public async Task<string?> GetModeratorIdByUserIdAsync(string? userId)
        {
            Moderator? moderator = await _moderatorRepository
               .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return null;
            }

            return moderator.Id.ToString();
        }

        public async Task<bool> HasEventWithIdAync(string userId, string eventId)
        {
            var moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return false;
            }

            var moderatorEvents = await _moderatorRepository
                .GetWithIncludeAsync(e => e.OwnedEvents);

            var e = moderatorEvents.FirstOrDefault(e => e.Id.ToString() == eventId);

            if (e == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ModeratorExistByUserIdAsync(string userId)
        {
            Moderator? moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return false;
            }

            return true;
        }
    }
}
