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
    public DateTime InjuryDate { get; set; }

    public bool IsActive { get; set; } = true;

    public int Age { get; set; } = 0;
    public string Gender { get; set; } = string.Empty;

    /*public enum PatientPhase
    {
       "Før behandling",
       "Efter behandling,
       "3 Måneder efter",
       "6 Måneder efter"
    }*/

}