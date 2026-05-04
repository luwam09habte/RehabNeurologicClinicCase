using Core.Models;
namespace ServerAPI.Interfaces;

public interface IUserRepository
{
    User[] GetAll();

    User? Validate(string email, string password);
}