using ReactApp1.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        Task<IEnumerable<User>> GetUsersAsync();
        void AddUser(User user);

        void SaveChanges();
    }
}
