namespace HMS_web.Models.Domain
{
    public class Appointments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Appointment{ get; set; }
    }
}
