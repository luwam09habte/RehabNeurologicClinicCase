namespace Core.Models;

public class Admin : User
{
    public int AdminId { get; set; } = 0;
    public string Role { get; set; } = string.Empty;
}

