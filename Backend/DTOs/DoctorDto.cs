namespace HealthcareAPI.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public string ConsultationFee { get; set; }
        public string AvailableSlots { get; set; }
        public bool IsAvailable { get; set; }
    }
}
