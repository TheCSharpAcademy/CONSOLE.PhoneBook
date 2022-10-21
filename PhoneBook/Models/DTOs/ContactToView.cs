namespace PhoneBook.Models.DTOs;

public class ContactToView
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    public string Category { get; set; }
}