using Core.Models;
namespace ServerAPI.Interfaces;

// Kontrakt for patient-repository
// Alle repositories der implementerer dette interface skal have disse metoder
public interface IPatientRepository
{
    Patient[] GetAll(); // Returnerer et array af Patient-objekter fra repository’et

    Patient? Validate(string email, string password); // // Tjekker om email og password matcher en patient
    // "?" = nullable returtype
}