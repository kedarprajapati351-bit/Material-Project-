using HealthcareAPI.Models;

namespace HealthcareAPI.Services
{
    public interface IBillingService
    {
        Task<Billing> GetBillingByIdAsync(int id);
        Task<IEnumerable<Billing>> GetAllBillingsAsync();
        Task<IEnumerable<Billing>> GetBillingsByPatientAsync(int patientId);
        Task<Billing> CreateBillingAsync(Billing billing);
        Task<Billing> UpdateBillingAsync(int id, Billing billing);
        Task<bool> DeleteBillingAsync(int id);
        Task<decimal> CalculateBalanceAsync(int billingId);
    }
}
