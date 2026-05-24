using HealthcareAPI.DTOs;
using HealthcareAPI.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(
            IAppointmentRepository repository,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> CancelAppointmentAsync(int id)
        {
            return await _repository.CancelAppointmentAsync(id);
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(Appointment appointment)
        {
            appointment.CreatedAt = DateTime.UtcNow;
            var result = await _repository.CreateAppointmentAsync(appointment);
            return await MapToDtoAsync(result);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _repository.GetAllAppointmentsAsync();
            var tasks = appointments.Select(a => MapToDtoAsync(a));
            return await Task.WhenAll(tasks);
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _repository.GetAppointmentByIdAsync(id);
            return appointment != null ? await MapToDtoAsync(appointment) : null;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId)
        {
            var appointments = await _repository.GetAppointmentsByDoctorAsync(doctorId);
            var tasks = appointments.Select(a => MapToDtoAsync(a));
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId)
        {
            var appointments = await _repository.GetAppointmentsByPatientAsync(patientId);
            var tasks = appointments.Select(a => MapToDtoAsync(a));
            return await Task.WhenAll(tasks);
        }

        public async Task<AppointmentDto> UpdateAppointmentAsync(int id, Appointment appointment)
        {
            appointment.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.UpdateAppointmentAsync(id, appointment);
            return result != null ? await MapToDtoAsync(result) : null;
        }

        private async Task<AppointmentDto> MapToDtoAsync(Appointment appointment)
        {
            if (appointment == null) return null;

            var patient = await _patientRepository.GetPatientByIdAsync(appointment.PatientId);
            var doctor = await _doctorRepository.GetDoctorByIdAsync(appointment.DoctorId);

            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                PatientName = $"{patient?.User?.FirstName} {patient?.User?.LastName}",
                DoctorName = $"{doctor?.User?.FirstName} {doctor?.User?.LastName}",
                DoctorSpecialization = doctor?.Specialization,
                AppointmentDate = appointment.AppointmentDate,
                TimeSlot = appointment.TimeSlot,
                Status = appointment.Status,
                Reason = appointment.Reason,
                ConsultationFee = appointment.ConsultationFee,
                CreatedAt = appointment.CreatedAt
            };
        }
    }
}
