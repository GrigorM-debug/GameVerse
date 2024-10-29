
using GameVerse.Services.Interfaces;

namespace GameVerse.Services
{
    public class BaseService : IBaseService
    {
        public bool IsGuidValid(string? id, ref Guid guidId)
        {
            if(String.IsNullOrEmpty(id)) return false;

            if(!Guid.TryParse(id, out guidId)) return false;

            return true;
        }
    }
}
