namespace HMS_web.Models.Domain
{
    public class Patients
    {
        public Guid Id { get; set; }
        public int PatientId { get; set; }
        public string PatientType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
    }
}
