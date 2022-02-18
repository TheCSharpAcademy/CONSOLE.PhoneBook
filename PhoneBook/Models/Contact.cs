namespace PhoneBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}