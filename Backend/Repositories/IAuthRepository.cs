using HealthcareAPI.Models;

namespace HealthcareAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
    }
}
