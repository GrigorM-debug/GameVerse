
using GameVerse.Services.Interfaces;

namespace GameVerse.Services
{
    public class ReviewService : IReviewService
    {
        public Task<bool> ReviewAlreadyExistByGameIdAndUserIdAsync(string userId, string gameId)
        {
            throw new NotImplementedException();
        }

        public Task AddReviewAsync(string userId, string gameId)
        {
            throw new NotImplementedException();
        }

        public Task EditReviewAsync(string reviewId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewAsync(string reviewId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
