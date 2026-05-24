namespace HealthcareAPI.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public int Duration { get; set; } // in days
        public string Instructions { get; set; }
        public DateTime PrescribedDate { get; set; }
        public bool IsActive { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
