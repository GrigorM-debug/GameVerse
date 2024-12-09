using System.Globalization;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Models;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Areas.Administrator.Services
{
    /// <summary>
    /// Service for managing event registrations and retrieving related data.
    /// </summary>
    /// <param name="eventsRegistrationsRepository">
    /// A repository for accessing event registration data.
    /// </param>
    public class EventsRegistrationsService(
        IGenericRepository<EventRegistration, object> _eventsRegistrationsRepository
        ) : IEventsRegistrationsService
    {
        /// <summary>
        /// Retrieves the total count of event registrations asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
        /// The task result contains the total number of event registrations as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetTotalEventsRegistrationsCountAsync()
        {
            int eventsRegistrationsTotalCount = await _eventsRegistrationsRepository
                .AllAsReadOnly()
                .CountAsync();

            return eventsRegistrationsTotalCount;
        }

        /// <summary>
        /// Validates whether a user's event registration is valid based on the provided QR code data.
        /// </summary>
        /// <param name="qrCodeData">The decoded QR code data containing event and user details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a boolean value indicating
        /// whether the user's event registration is valid.
        /// </returns>
        public async Task<bool> IsUserEventRegistrationValidAsync(DecodedDataViewModel qrCodeData)
        {
            var userEventRegistration = await _eventsRegistrationsRepository.AllAsReadOnly().FirstOrDefaultAsync(er => er.UserId.ToString() == qrCodeData.UserId && er.EventId.ToString() == qrCodeData.EventId);

            if (userEventRegistration == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retrieves detailed information about a user's event registration based on the provided QR code data.
        /// </summary>
        /// <param name="qrCodeData">The decoded QR code data containing event and user details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a <see cref="UserEventRegistrationInfoViewModel"/>
        /// with detailed user registration information for the event, or null if no valid registration is found.
        /// </returns>
        public async Task<UserEventRegistrationInfoViewModel> GetUserEventRegistrationInfo(DecodedDataViewModel qrCodeData)
        {
            UserEventRegistrationInfoViewModel? userEventRegistration = await _eventsRegistrationsRepository
                .GetWithIncludeAsync(er => er.User, er => er.Event)
                .Where(er => er.UserId.ToString() == qrCodeData.UserId && er.EventId.ToString() == qrCodeData.EventId)
                .Select(er => new UserEventRegistrationInfoViewModel()
                {
                    UserName = er.User.UserName,
                    FullName = $"{er.User.FirstName} {er.User.LastName}",
                    EventTopic = er.Event.Topic,
                    StartDate = er.Event.StartDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    EndDate = er.Event.EndDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    NumberOfTickets = er.TicketQuantity,
                    PricePaid = (er.TicketQuantity * er.Event.TicketPrice).ToString("C"),
                    RegistrationDate = er.RegistrationDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture)
                }).FirstOrDefaultAsync();

            return userEventRegistration;
        }
    }
}
