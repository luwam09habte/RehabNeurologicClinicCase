namespace Core.Models;
// Data skabelon
// String empty = starter som en tom tekst i stedet for null
// User = fælles grundklasse for brugere i systemet.

public class User
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}