

namespace GameVerse.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<bool> ModeratorExistByUserIdAsync(string userId);

        Task<string?> GetModeratorIdByUserIdAsync(string? userId);

        Task InCreaseCreatedTotalEventsCount(string moderatorId);
    }
}
