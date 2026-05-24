using HealthcareAPI.DTOs;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetDoctorByIdAsync(int id);
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization);
        Task<DoctorDto> CreateDoctorAsync(Doctor doctor);
        Task<DoctorDto> UpdateDoctorAsync(int id, Doctor doctor);
        Task<bool> DeleteDoctorAsync(int id);
    }
}
