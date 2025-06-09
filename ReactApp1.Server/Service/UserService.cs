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
            };

            if (userDTO.Posts != null && userDTO.Posts.Any())
            {
                user.Posts = userDTO.Posts.Select(post => new Post
                {
                    Text = post.Text,
                }).ToList();

            }

            _userRepository.AddUser(user);

            _userRepository.SaveChanges();

            var result = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreateTime = user.CreateTime,
                Posts = user.Posts?.Select(p => new PostDTO
                {
                    Id = p.Id,
                    Text = p.Text,
                    CreatedAt = p.CreateTime,
                    UserId = p.UserId
                }).ToList()
            };

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
