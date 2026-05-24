namespace HealthcareAPI.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string PaymentStatus { get; set; } // Pending, Partial, Complete
        public string PaymentMethod { get; set; } // Cash, Card, UPI, Cheque
        public DateTime BillingDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }
    }
}
