

using GameVerse.Data.Models.Games.Review;
using GameVerse.Web.ViewModels.Game.Review;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing game reviews.
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Checks if a review already exists for a given game by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the review exists.</returns>
        Task<bool> ReviewAlreadyExistByGameIdAndUserIdAsync(string userId, string gameId);

        /// <summary>
        /// Adds a new review for a specific game by a user.
        /// </summary>
        /// <param name="inputModel">The input model containing review details.</param>
        /// <param name="userId">The ID of the user adding the review.</param>
        /// <param name="gameId">The ID of the game being reviewed.</param>
        /// <param name="createdOn">The date and time when the review is created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the review was added successfully.</returns>
        Task<bool> AddReviewAsync(ReviewInputViewModel inputModel, string userId, string gameId, DateTime createdOn);

        /// <summary>
        /// Retrieves the review data for editing by a specific user.
        /// </summary>
        /// <param name="reviewId">The ID of the review to edit.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <param name="userId">The ID of the user requesting the edit.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the input model with existing review details.</returns>
        Task<ReviewInputViewModel> EditViewGetAsync(string reviewId, string gameId, string userId);

        /// <summary>
        /// Updates an existing review with new details.
        /// </summary>
        /// <param name="inputModel">The input model containing updated review details.</param>
        /// <param name="createdOn">The date and time when the review was last modified.</param>
        /// <param name="reviewId">The ID of the review to update.</param>
        /// <param name="userId">The ID of the user updating the review.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the update was successful.</returns>
        Task<bool> EditReviewPostAsync(ReviewInputViewModel inputModel, DateTime createdOn, string reviewId, string userId, string gameId);

        /// <summary>
        /// Retrieves data for deleting a specific review.
        /// </summary>
        /// <param name="reviewId">The ID of the review to delete.</param>
        /// <param name="userId">The ID of the user requesting deletion.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a view model for deleting the review.</returns>
        Task<ReviewDeleteViewModel> DeleteReviewGetAsync(string reviewId, string userId, string gameId);

        /// <summary>
        /// Deletes an existing review.
        /// </summary>
        /// <param name="reviewId">The ID of the review to delete.</param>
        /// <param name="userId">The ID of the user deleting the review.</param>
        /// <param name="gameId">The ID of the game associated with the review.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteReviewPostAsync(string reviewId, string userId, string gameId);
    }
}
