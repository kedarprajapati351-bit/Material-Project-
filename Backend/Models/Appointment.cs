namespace HealthcareAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Cancelled, No-Show
        public string Reason { get; set; }
        public string Notes { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
