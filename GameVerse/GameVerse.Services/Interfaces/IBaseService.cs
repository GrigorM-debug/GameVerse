namespace GameVerse.Services.Interfaces
{
    internal interface IBaseService
    {
        bool IsGuidValid(string? id, ref Guid guidId);
    }
}
