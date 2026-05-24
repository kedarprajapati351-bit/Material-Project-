using HealthcareAPI.DTOs;
using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<AppointmentDto> CreateAppointmentAsync(Appointment appointment);
        Task<AppointmentDto> UpdateAppointmentAsync(int id, Appointment appointment);
        Task<bool> CancelAppointmentAsync(int id);
    }
}
