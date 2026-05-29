namespace Core.Models;

public class Patient : User
{
    public int PatientId { get; set; } = 0;
    public string PhoneNumber { get; set; } = string.Empty;
    public string InjuryType { get; set; } = string.Empty;
    public DateTime? InjuryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int Age { get; set; } = 0;
    public string Gender { get; set; } = string.Empty;
}