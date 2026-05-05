using Core.Models;
namespace ServerAPI.Interfaces;

public interface IAdminRepository
{
    Admin[] GetAll();

    Admin? Validate(string email, string password);
}