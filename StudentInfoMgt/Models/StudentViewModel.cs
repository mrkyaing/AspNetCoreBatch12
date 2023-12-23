namespace StudentInfoMgt.Models
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string NRC { get; set; }
        public string FatherName { get; set; }
        public string? Address { get; set; }
    }
}
