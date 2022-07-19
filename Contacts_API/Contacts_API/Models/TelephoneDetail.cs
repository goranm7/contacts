namespace Contacts_API.Models
{
    public class TelephoneDetail
    {
        public int Id { get; set; }
        public string Telephone { get; set; } = string.Empty;

        public int ContactDetailId { get; set; }
        
    }
}
