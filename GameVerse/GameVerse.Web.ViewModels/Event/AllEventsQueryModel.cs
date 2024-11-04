

using GameVerse.Common.Enums;

namespace GameVerse.Web.ViewModels.Event
{
    public class AllEventsQueryModel
    {
        public int CurrentPage { get; set; } = 1;

        public int EventsPerPage { get; set; } = 6;

        public int TotalEventsCount { get; set; }

        public EventSortOrder EventSelectedSortOrder { get; set; } = EventSortOrder.Newest;

        public IEnumerable<EventIndexViewModel> Events { get; set; } = new HashSet<EventIndexViewModel>();
    }
}
