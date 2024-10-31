using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces.Events;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services.Events
{
    public class EventService : BaseService, IEventService
    {
        private readonly IGenericRepository<Event, Guid> _eventRepository;

        public EventService(IGenericRepository<Event, Guid> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> AddEventAsync(EventInputViewModel inputModel)
        {
            if(DateTime.TryParseExact(inputModel.StartDate, EventConstants.EventDateTimeFormat , CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate) == false)
            {
                return false;
            }

            if (DateTime.TryParseExact(inputModel.EndDate, EventConstants.EventDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate) == false)
            {
                return false;
            }

            Event newEvent = new Event()
            {

            };

            return true;
        }

        public async Task<bool> EventExist(Guid id)
        {
            Event? isExisting = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id == id);

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

        public async Task<EventDetailsViewModel> GetEventDetailsByIdAsync(Guid id)
        {
            Event? e = await _eventRepository.GetByIdAsync(id);

            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel()
            {
                Id = e.Id.ToString(),
                Topic = e.Topic,
                Description = e.Description,
                StartDate = e.StartDate.ToString(EventConstants.EventDateTimeFormat),
                EndDate = e.EndDate.ToString( EventConstants.EventDateTimeFormat),
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Seats = e.Seats,
                TicketPrice = e.TicketPrice.ToString("C"),
                Image = e.Image,
            };

            return eventDetailsViewModel;
        }
    }
}
