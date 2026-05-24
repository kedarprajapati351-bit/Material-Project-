using HealthcareAPI.DTOs;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> CreatePatientAsync(Patient patient);
        Task<PatientDto> UpdatePatientAsync(int id, Patient patient);
        Task<bool> DeletePatientAsync(int id);
        Task<PatientDto> GetPatientByUserIdAsync(int userId);
    }
}
