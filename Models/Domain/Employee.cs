namespace HMS_web.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }

    }
}
