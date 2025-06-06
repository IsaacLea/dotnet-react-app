using ReactApp1.Server.DTO;

namespace ReactApp1.Server.Service
{
    public interface IUserService
    {

        Task<IEnumerable<UserDTO>> GetUsers();
        void AddUser(UserDTO user);

    }
}
