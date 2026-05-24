using HealthcareAPI.DTOs;
using HealthcareAPI.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<DoctorDto> CreateDoctorAsync(Doctor doctor)
        {
            var result = await _repository.CreateDoctorAsync(doctor);
            return MapToDto(result);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            return await _repository.DeleteDoctorAsync(id);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _repository.GetAllDoctorsAsync();
            return doctors.Select(MapToDto);
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repository.GetDoctorByIdAsync(id);
            return doctor != null ? MapToDto(doctor) : null;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string specialization)
        {
            var doctors = await _repository.GetDoctorsBySpecializationAsync(specialization);
            return doctors.Select(MapToDto);
        }

        public async Task<DoctorDto> UpdateDoctorAsync(int id, Doctor doctor)
        {
            var result = await _repository.UpdateDoctorAsync(id, doctor);
            return result != null ? MapToDto(result) : null;
        }

        private DoctorDto MapToDto(Doctor doctor)
        {
            if (doctor == null) return null;

            return new DoctorDto
            {
                Id = doctor.Id,
                UserId = doctor.UserId,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                Email = doctor.User?.Email,
                PhoneNumber = doctor.User?.PhoneNumber,
                LicenseNumber = doctor.LicenseNumber,
                Specialization = doctor.Specialization,
                Qualification = doctor.Qualification,
                ExperienceYears = doctor.ExperienceYears,
                ConsultationFee = doctor.ConsultationFee,
                AvailableSlots = doctor.AvailableSlots,
                IsAvailable = doctor.IsAvailable
            };
        }
    }
}
