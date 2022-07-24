namespace Contacts_API.Models
{
    public class Telephone
    {
        public int Id { get; set; }
        public string Phone { get; set; } = string.Empty;

        public int ContactId { get; set; }
        
    }
}
