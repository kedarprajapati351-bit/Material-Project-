namespace HealthcareAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MRN { get; set; } // Medical Record Number
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string EmergencyContact { get; set; }
        public string Allergies { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Billing> Billings { get; set; }
    }
}
