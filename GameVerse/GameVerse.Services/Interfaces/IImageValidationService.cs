
using System.Threading.Tasks;

namespace GameVerse.Services.Interfaces
{
    public interface IImageValidationService
    {
        Task<bool> ValidateImageWithApi(string imageUrl);
    }
}
