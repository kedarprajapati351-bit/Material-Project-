namespace HealthcareAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LicenseNumber { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public string ConsultationFee { get; set; }
        public string AvailableSlots { get; set; }
        public bool IsAvailable { get; set; }
        public string OfficeAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
