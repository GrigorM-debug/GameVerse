

namespace GameVerse.Services.Interfaces
{
    internal interface IReviewService
    {
        Task<bool> ReviewAlreadyExistByGameIdAndUserIdAsync(string userId, string gameId);

        Task AddReviewAsync(string userId, string gameId);

        Task EditReviewAsync(string reviewId, string userId);

        Task DeleteReviewAsync(string reviewId, string userId);
    }
}
