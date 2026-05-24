using HealthcareAPI.Models;
using HealthcareAPI.Repositories;

namespace HealthcareAPI.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;

        public BillingService(IBillingRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> CalculateBalanceAsync(int billingId)
        {
            var billing = await _repository.GetBillingByIdAsync(billingId);
            if (billing == null) return 0;

            return billing.TotalAmount - billing.PaidAmount;
        }

        public async Task<Billing> CreateBillingAsync(Billing billing)
        {
            billing.BillingDate = DateTime.UtcNow;
            billing.TotalAmount = billing.ConsultationFee + billing.LabCharges + 
                                 billing.MedicineCharges + billing.OtherCharges;
            billing.BalanceAmount = billing.TotalAmount - billing.PaidAmount;
            billing.PaymentStatus = billing.PaidAmount == 0 ? "Pending" : 
                                   billing.PaidAmount < billing.TotalAmount ? "Partial" : "Complete";

            return await _repository.CreateBillingAsync(billing);
        }

        public async Task<bool> DeleteBillingAsync(int id)
        {
            return await _repository.DeleteBillingAsync(id);
        }

        public async Task<IEnumerable<Billing>> GetAllBillingsAsync()
        {
            return await _repository.GetAllBillingsAsync();
        }

        public async Task<Billing> GetBillingByIdAsync(int id)
        {
            return await _repository.GetBillingByIdAsync(id);
        }

        public async Task<IEnumerable<Billing>> GetBillingsByPatientAsync(int patientId)
        {
            return await _repository.GetBillingsByPatientAsync(patientId);
        }

        public async Task<Billing> UpdateBillingAsync(int id, Billing billing)
        {
            billing.TotalAmount = billing.ConsultationFee + billing.LabCharges + 
                                 billing.MedicineCharges + billing.OtherCharges;
            billing.BalanceAmount = billing.TotalAmount - billing.PaidAmount;
            billing.PaymentStatus = billing.PaidAmount == 0 ? "Pending" : 
                                   billing.PaidAmount < billing.TotalAmount ? "Partial" : "Complete";

            return await _repository.UpdateBillingAsync(id, billing);
        }
    }
}
