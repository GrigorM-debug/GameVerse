
using System.Globalization;
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game.Review;
using Microsoft.EntityFrameworkCore;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services
{
    /// <summary>
    /// Implements the review management functionality for games.
    /// </summary>
    public class ReviewService(IGenericRepository<GameReview, Guid> reviewRepository) : IReviewService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewService"/> class.
        /// </summary>
        /// <param name="reviewRepository">The repository for managing game reviews.</param>
        private readonly IGenericRepository<GameReview, Guid> _reviewRepository = reviewRepository;

        /// <summary>
        /// Checks if a review already exists for a given game by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the review exists.</returns>
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

        /// <summary>
        /// Adds a new review for a specific game by a user.
        /// </summary>
        /// <param name="inputModel">The input model containing review details.</param>
        /// <param name="userId">The ID of the user adding the review.</param>
        /// <param name="gameId">The ID of the game being reviewed.</param>
        /// <param name="createdOn">The date and time when the review is created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the review was added successfully.</returns>
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

        /// <summary>
        /// Retrieves the review data for editing by a specific user.
        /// </summary>
        /// <param name="reviewId">The ID of the review to edit.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <param name="userId">The ID of the user requesting the edit.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the input model with existing review details.</returns>
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

        /// <summary>
        /// Updates an existing review with new details.
        /// </summary>
        /// <param name="inputModel">The input model containing updated review details.</param>
        /// <param name="createdOn">The date and time when the review was last modified.</param>
        /// <param name="reviewId">The ID of the review to update.</param>
        /// <param name="userId">The ID of the user updating the review.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the update was successful.</returns>
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

        /// <summary>
        /// Retrieves data for deleting a specific review.
        /// </summary>
        /// <param name="reviewId">The ID of the review to delete.</param>
        /// <param name="userId">The ID of the user requesting deletion.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a view model for deleting the review.</returns>
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

        /// <summary>
        /// Deletes an existing review.
        /// </summary>
        /// <param name="reviewId">The ID of the review to delete.</param>
        /// <param name="userId">The ID of the user deleting the review.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the deletion was successful.</returns>
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
