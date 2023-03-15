
namespace DBProject.Models;

internal class CustomerTicket
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Description { get; set; } = null!;
    public DateTime SubmittedTime { get; set; }
    public string Status { get; set; } = null!;

}
