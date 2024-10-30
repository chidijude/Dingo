using System.Net;

namespace Dingo.Api.Domain;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Email { get; set; }
    public required string Usernmae { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateOnly? DateOfBirth { get; set; }
    public string Role { get; set; } = "Customer";
}
