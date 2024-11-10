
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Services
{
    public class ReviewService(IGenericRepository<GameReview, Guid> reviewRepository) : IReviewService
    {
        private readonly IGenericRepository<GameReview, Guid> _reviewRepository = reviewRepository;

        public async Task<bool> ReviewAlreadyExistByGameIdAndUserIdAsync(string userId, string gameId)
        {
            GameReview? review = await _reviewRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(r => r.GameId.ToString() == gameId && r.ReviewerId.ToString() == userId && r.IsDeleted == false);

            if (review == null)
            {
                return false;
            }

            return true;
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
