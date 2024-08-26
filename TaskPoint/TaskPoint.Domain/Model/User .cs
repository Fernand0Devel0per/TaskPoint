using TaskPoint.Domain.Tools.Enums;

namespace TaskPoint.Domain.Model;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public UserRole Role { get; set; }

    public ICollection<Task> Tasks { get; set; }
    public ICollection<Project> Projects { get; set; }
}
