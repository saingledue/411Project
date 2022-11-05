
using MudServer.ViewModels;

namespace MudServer.Managers.Interfaces
{
    public interface IUserManager
    {
        public Task<UserView> CreateUserAsync(UserView user);
        public int GetUserIdByEmail(string email);
    }
}
