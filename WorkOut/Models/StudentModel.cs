namespace WorkOut.Models
{
    public class StudentModel
    {
        public string FristName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public string Gender { get; set; }
        public string CountryCode { get; set; }//PascalCase 
        public  string? Phone { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public HomeAddressModel HomeAddress { get; set; }//Has-A Relationship
    }
}
