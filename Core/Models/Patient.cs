namespace Core.Models;

public class Patient
{
    public int PatientId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string InjuryType { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    
    /*public enum PatientPhase { get; set; }*/

}