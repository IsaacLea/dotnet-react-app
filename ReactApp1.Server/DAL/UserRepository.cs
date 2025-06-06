using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.DAL
{
    public class UserRepository(SQLServerContext userContext) : IUserRepository
    {
        private readonly SQLServerContext _userContext = userContext;

        public void AddUser(User user)
        {
            _userContext.Set<User>().Add(user);
        }

        public async Task AddUserAsync(User user)
        {
            await _userContext.Set<User>().AddAsync(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userContext.Set<User>();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext.Set<User>().ToListAsync();
        }

        public void SaveChanges()
        {
            _userContext.SaveChanges();
        }

    }
}
