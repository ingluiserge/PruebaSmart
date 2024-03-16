namespace PruebaSmart.Model
{
    public class Huesped
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }        
        public string Phone { get; set; }
        public string EmergencyContactFullName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
    }
}
