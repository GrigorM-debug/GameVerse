using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services
{
    public class EventService : BaseService, IEventService
    {
        private readonly IGenericRepository<Event, Guid> _eventRepository;

        public EventService(IGenericRepository<Event, Guid> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<string> AddEventAsync(EventInputViewModel inputModel, string userId, DateTime startDate, DateTime endDate)
        {
            Event newEvent = new Event()
            {
                Topic = inputModel.Topic,
                Description = inputModel.Description,
                StartDate = startDate,
                EndDate = endDate,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude,
                Seats = inputModel.Seats,
                TicketPrice = inputModel.TicketPrice,
                Image = inputModel.Image,
                PublisherId = Guid.Parse(userId)
            };

            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();

            return newEvent.Id.ToString();
        }

        public async Task<EventDeleteViewModel?> DeleteEventGetAsync(string eventId, string userId)
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            Event? e = events.FirstOrDefault(e => e.Id.ToString() == eventId && e.Publisher.UserId.ToString() == userId && e.IsDeleted == false);

            EventDeleteViewModel model = new EventDeleteViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                PublisherName = e.Publisher.User.UserName,
                PublisherId = e.PublisherId.ToString(),
            };

            return model;
        }

        public async Task DeleteEventPostAsync(string eventId, string moderatorId)
        {
            Event? e = await _eventRepository
                .FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            e.IsDeleted = true;

            await _eventRepository.SaveChangesAsync();


        }

        public async Task<EventInputViewModel?> EditEventGetAsync(string eventId, string userId)
        {
            Event? e = await _eventRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.Publisher.UserId.ToString() == userId && e.IsDeleted == false);

            EventInputViewModel model = new EventInputViewModel()
            {
                Topic = e.Topic,
                Description = e.Description,
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice,
                Image = e.Image,
            };

            return model;
        }

        public async Task<string> EditEventPostAsync(EventInputViewModel inputModel, string eventId, string moderatorId, DateTime startDate, DateTime endDate)
        {
            Event? e = await _eventRepository.FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.PublisherId.ToString() == moderatorId && e.IsDeleted == false);

            if(e != null)
            {
                e.Topic = inputModel.Topic;
                e.Description = inputModel.Description;
                e.StartDate = startDate;
                e.EndDate = endDate;
                e.Latitude = inputModel.Latitude;
                e.Longitude = inputModel.Longitude;
                e.Seats = inputModel.Seats;
                e.TicketPrice = inputModel.TicketPrice;
                e.Image = inputModel.Image;
                e.PublisherId = Guid.Parse(moderatorId);
            }

            await _eventRepository.SaveChangesAsync();

            return e.Id.ToString();
        }

        public async Task<bool> EventExistById(string id)
        {
            Event? result = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id.ToString() == id && e.IsDeleted == false);


            if (result == null)
                return false;


            return true;
        }

        public async Task<bool> EventExistByTitle(string topic)
        {
            Event? isExisting = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Topic == topic && e.IsDeleted == false);

            if (isExisting == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<EventIndexViewModel>> GetAllEventsAsync()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllAsyncAsReadOnly();

            IEnumerable<EventIndexViewModel> eventIndexViewModels = events
                .Select(e => new EventIndexViewModel
                {
                    Id = e.Id.ToString(),
                    Topic = e.Topic,
                    StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                    EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice.ToString("C"),
                    Image = e.Image,
                });

            return eventIndexViewModels;
        }

        public async Task<EventDetailsViewModel> GetEventDetailsByIdAsync(string id)
        {
            IEnumerable<Event> events = await _eventRepository.GetWithIncludeAsync(e => e.Publisher.User);

            Event? e = events.FirstOrDefault(x => x.Id.ToString() == id);

            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                Description = e.Description,
                StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                EndDate = e.EndDate.ToString(EventConstants.EventDateTimeFormat),
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice.ToString("C"),
                Image = e.Image,
                PublisherName = e.Publisher.User.UserName
            };

            return eventDetailsViewModel;
        }

        public async Task<bool> HasPublisherWithIdAsync(string userId, string eventId)
        {
            Event? e = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.Publisher.UserId.ToString() == userId);

            if (e == null)
            {
                return false;
            }

            return true;
        }
    }
}
