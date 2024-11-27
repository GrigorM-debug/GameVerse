
using System.Threading.Tasks;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for validating images, such as verifying the validity of image URLs using an external API.
    /// </summary>
    public interface IImageValidationService
    {
        /// <summary>
        /// Validates an image using an external API.
        /// </summary>
        /// <param name="imageUrl">The URL of the image to validate.</param>
        /// <returns>
        /// A task containing a <c>true</c> value if the image is valid; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> ValidateImageWithApi(string imageUrl);
    }
}
