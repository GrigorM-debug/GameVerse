

using GameVerse.Data.Models.Games.Review;
using GameVerse.Web.ViewModels.Game.Review;

namespace GameVerse.Services.Interfaces
{
    public interface IReviewService
    {
        Task<bool> ReviewAlreadyExistByGameIdAndUserIdAsync(string userId, string gameId);

        Task AddReviewAsync(ReviewInputViewModel inputModel, string userId, string gameId, DateTime createdOn);

        Task<ReviewInputViewModel> EditViewGetAsync(string reviewId, string gameId, string userId);

        Task EditReviewPostAsync(ReviewInputViewModel inputModel, DateTime createdOn, string reviewId, string userId, string gameId);

        Task DeleteReviewAsync(string reviewId, string userId, string gameId);
    }
}
