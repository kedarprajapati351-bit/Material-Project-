using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public interface IPrescriptionService
    {
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<IEnumerable<Prescription>> GetPrescriptionsByPatientAsync(int patientId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorAsync(int doctorId);
        Task<Prescription> CreatePrescriptionAsync(Prescription prescription);
        Task<Prescription> UpdatePrescriptionAsync(int id, Prescription prescription);
        Task<bool> DeletePrescriptionAsync(int id);
    }
}
