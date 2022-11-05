using AutoMapper;
using MudServer.Data;
using MudServer.DataAccess.Models;
using MudServer.Managers.Interfaces;
using MudServer.ViewModels;

namespace MudServer.Managers
{
    public class UserManager : IUserManager
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserManager(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserView> CreateUserAsync(UserView obj)
        {
            var user = _mapper.Map<UserView, User>(obj);
            var addedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserView>(addedUser.Entity);
        }

        public int GetUserIdByEmail(string email)
        {
            var userData = _context.Users.FirstOrDefault(x => x.email == email);
            if (userData != null)
            {
                return userData.Id;
            }

            return -1;
        }
    }
}
