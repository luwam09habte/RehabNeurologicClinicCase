namespace Core.Models;

public class User
{
    public int UserId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public class Patient
{
    public int PatientId { get; set; } = 0;
}

