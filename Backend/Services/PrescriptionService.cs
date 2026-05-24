using HealthcareAPI.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Prescription> CreatePrescriptionAsync(Prescription prescription)
        {
            prescription.PrescribedDate = DateTime.UtcNow;
            return await _repository.CreatePrescriptionAsync(prescription);
        }

        public async Task<bool> DeletePrescriptionAsync(int id)
        {
            return await _repository.DeletePrescriptionAsync(id);
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _repository.GetAllPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _repository.GetPrescriptionByIdAsync(id);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorAsync(int doctorId)
        {
            return await _repository.GetPrescriptionsByDoctorAsync(doctorId);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientAsync(int patientId)
        {
            return await _repository.GetPrescriptionsByPatientAsync(patientId);
        }

        public async Task<Prescription> UpdatePrescriptionAsync(int id, Prescription prescription)
        {
            return await _repository.UpdatePrescriptionAsync(id, prescription);
        }
    }
}
