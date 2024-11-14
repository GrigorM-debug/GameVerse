
using System.Globalization;
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game.Review;
using Microsoft.EntityFrameworkCore;
using static GameVerse.Common.ApplicationConstants;

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


        public async Task<bool> AddReviewAsync(ReviewInputViewModel inputModel, string userId, string gameId, DateTime createdOn)
        {
            GameReview? review = await _reviewRepository.FirstOrDefaultAsync(r =>
                r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId);

            if (review != null)
            {
                if (review.IsDeleted == true)
                {
                    review.IsDeleted = false;
                    await _reviewRepository.SaveChangesAsync();
                    return true;
                }

                return false;
            }

            if (review == null)
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
                await _reviewRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ReviewInputViewModel> EditViewGetAsync(string reviewId, string gameId, string userId)
        {
            GameReview? review = await _reviewRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(r =>
                    r.Id.ToString() == reviewId
                    && r.GameId.ToString() == gameId
                    && r.ReviewerId.ToString() == userId
                    && r.IsDeleted == false);

            ReviewInputViewModel model = new ReviewInputViewModel();

            if (review != null)
            {
                model = new ReviewInputViewModel
                {
                    Content = review.Content,
                    Rating = review.Rating,
                    CreatedOn = review.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    GameId = review.GameId.ToString()
                };
            }

            return model;
        }

        public async Task<bool> EditReviewPostAsync(ReviewInputViewModel inputModel, DateTime createdOn, string reviewId, string userId, string gameId)
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

                return true;
            }

            return false;
        }

        public async Task<ReviewDeleteViewModel> DeleteReviewGetAsync(string reviewId, string userId, string gameId)
        {
            GameReview? review = await _reviewRepository
                .GetWithIncludeAsync(r => r.Reviewer, r => r.Game)
                .FirstOrDefaultAsync(r =>
                r.Id.ToString() == reviewId && r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId &&
                r.IsDeleted == false);

            ReviewDeleteViewModel model = new ReviewDeleteViewModel();

            if (review != null)
            {
                model.Id = review.Id.ToString();
                model.Content = review.Content;
                model.Rating = review.Rating;
                model.ReviewerId = review.ReviewerId.ToString();
                model.ReviewerName = review.Reviewer.UserName;
                model.CreatedOn = review.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
                model.GameName = review.Game.Title;
                model.GameId = review.GameId.ToString();
            }

            return model;
        }

        public async Task<bool> DeleteReviewPostAsync(string reviewId, string userId, string gameId)
        {
            GameReview? review = await _reviewRepository.FirstOrDefaultAsync(r =>
                r.Id.ToString() == reviewId && r.ReviewerId.ToString() == userId && r.GameId.ToString() == gameId &&
                r.IsDeleted == false);

            if (review != null)
            {
                review.IsDeleted = true;
                await _reviewRepository.SaveChangesAsync();
                return true;
            }

            return false;   
        }
    }
}
