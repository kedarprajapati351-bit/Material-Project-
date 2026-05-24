using HealthcareAPI.DTOs;

namespace HealthcareAPI.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<LoginResponse> RegisterAsync(RegisterRequest request);
        Task<bool> ValidateTokenAsync(string token);
    }
}
