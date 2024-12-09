using GameVerse.Web.Areas.Administrator.Models;

namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing and retrieving information about event registrations.
    /// </summary>
    public interface IEventsRegistrationsService
    {
        /// <summary>
        /// Retrieves the total count of event registrations asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of event registrations as an <see cref="int"/>.
        /// </returns>
        Task<int> GetTotalEventsRegistrationsCountAsync();

        /// <summary>
        /// Validates whether a user's event registration is valid based on the provided QR code data.
        /// </summary>
        /// <param name="qrCodeData">The decoded QR code data containing event and user details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a boolean value indicating
        /// whether the user's event registration is valid.
        /// </returns>
        Task<bool> IsUserEventRegistrationValidAsync(DecodedDataViewModel qrCodeData);

        /// <summary>
        /// Retrieves detailed information about a user's event registration based on the provided QR code data.
        /// </summary>
        /// <param name="qrCodeData">The decoded QR code data containing event and user details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a <see cref="UserEventRegistrationInfoViewModel"/>
        /// with detailed user registration information for the event, or null if no valid registration is found.
        /// </returns>
        Task<UserEventRegistrationInfoViewModel> GetUserEventRegistrationInfo(DecodedDataViewModel qrCodeData);
    }
}
