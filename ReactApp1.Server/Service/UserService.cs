using ReactApp1.Server.DAL;
using ReactApp1.Server.DTO;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Service
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public void AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                //CreateAt = DateTime.UtcNow
            };

            _userRepository.AddUser(user);

            _userRepository.SaveChanges();
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }
    }
}
