namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    public interface IEventsRegistrationsService
    {
        Task<int> GetTotalEventsRegistrationsCountAsync();
    }
}
