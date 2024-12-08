

using Microsoft.AspNetCore.Identity;
using Moq;

namespace GameVerse.Services.Tests
{
    public class MockHelper
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            return new Mock<UserManager<TUser>>(
                store.Object, null, null, null, null, null, null, null, null
            );
        }
    }
}
