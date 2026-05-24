using HealthcareAPI.DTOs;
using HealthcareAPI.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientDto> CreatePatientAsync(Patient patient)
        {
            var result = await _repository.CreatePatientAsync(patient);
            return MapToDto(result);
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            return await _repository.DeletePatientAsync(id);
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _repository.GetAllPatientsAsync();
            return patients.Select(MapToDto);
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetPatientByIdAsync(id);
            return patient != null ? MapToDto(patient) : null;
        }

        public async Task<PatientDto> GetPatientByUserIdAsync(int userId)
        {
            var patient = await _repository.GetPatientByUserIdAsync(userId);
            return patient != null ? MapToDto(patient) : null;
        }

        public async Task<PatientDto> UpdatePatientAsync(int id, Patient patient)
        {
            var result = await _repository.UpdatePatientAsync(id, patient);
            return result != null ? MapToDto(result) : null;
        }

        private PatientDto MapToDto(Patient patient)
        {
            if (patient == null) return null;

            return new PatientDto
            {
                Id = patient.Id,
                UserId = patient.UserId,
                Username = patient.User?.Username,
                Email = patient.User?.Email,
                FirstName = patient.User?.FirstName,
                LastName = patient.User?.LastName,
                MRN = patient.MRN,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                Address = patient.Address,
                City = patient.City,
                PhoneNumber = patient.User?.PhoneNumber,
                Allergies = patient.Allergies,
                ChronicDiseases = patient.ChronicDiseases,
                RegistrationDate = patient.RegistrationDate
            };
        }
    }
}
