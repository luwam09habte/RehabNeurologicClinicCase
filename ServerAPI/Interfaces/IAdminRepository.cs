using Core.Models;
namespace ServerAPI.Interfaces;

// Kontrakt for admin-repository
// Alle repositories der implementerer dette interface skal have disse metoder
public interface IAdminRepository
{
    Admin[] GetAll(); // Returnerer et array af Admin-objekter fra repository’et

    Admin? Validate(string email, string password); // Tjekker om email og password matcher en admin
    // "?" = nullable returtype
}