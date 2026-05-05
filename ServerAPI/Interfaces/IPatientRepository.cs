using Core.Models;
namespace ServerAPI.Interfaces;

public interface IPatientRepository
{
    Patient[] GetAll();

    Patient? Validate(string email, string password);
}