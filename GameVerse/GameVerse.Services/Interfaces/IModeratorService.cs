

namespace GameVerse.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<bool> ModeratorExistByUserIdAsync(string userId);

        Task<bool> HasEventWithIdAsync(string userId, string eventId);

        Task<string?> GetModeratorIdByUserIdAsync(string? userId);


    }
}
