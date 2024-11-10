
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game.Review;
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

        public async Task AddReviewAsync(ReviewInputViewModel inputModel, string userId, string gameId, DateTime createdOn)
        {
            GameReview? review = await _reviewRepository.FirstOrDefaultAsync(r =>
                r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId);

            if (review != null)
            {
                if (review.IsDeleted == true)
                {
                    review.IsDeleted = false;
                }
            }
            else
            {
                review = new GameReview()
                {
                    Content = inputModel.Content,
                    Rating = inputModel.Rating,
                    CreatedOn = createdOn,
                    GameId = Guid.Parse(gameId),
                    ReviewerId = Guid.Parse(userId)
                };

                await _reviewRepository.AddAsync(review);
            }

            await _reviewRepository.SaveChangesAsync();
        }

        public async Task EditReviewAsync(ReviewInputViewModel inputModel, DateTime createdOn, string reviewId, string userId, string gameId)
        {
            GameReview? review = await _reviewRepository.FirstOrDefaultAsync(r =>
                r.Id.ToString() == reviewId && r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId &&
                r.IsDeleted == false);

            if (review != null)
            {
                review.Content = inputModel.Content;
                review.Rating = inputModel.Rating;
                review.CreatedOn = createdOn;
                review.GameId = Guid.Parse(gameId);
                review.ReviewerId = Guid.Parse(userId);
                review.IsDeleted = false;

                await _reviewRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteReviewAsync(string reviewId, string userId, string gameId)
        {
            GameReview? review = await _reviewRepository.FirstOrDefaultAsync(r =>
                r.Id.ToString() == reviewId && r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId &&
                r.IsDeleted == false);

            if (review != null)
            {
                review.IsDeleted = true;
                await _reviewRepository.SaveChangesAsync();
            }
        }
    }
}
