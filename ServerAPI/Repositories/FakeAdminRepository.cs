using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeAdminRepository : IAdminRepository
{
    private List<Admin> fUsers =
    [
        new Admin() { AdminId = 1, Name = "Admin", Password = "Admin123", Email = "Hans123@gmail.com", Role = "Admin" },
    ];

    public Admin[] GetAll()
    {
        return fUsers.ToArray();
    }

    public Admin? Validate(string email, string password)
    {
        foreach (Admin a in fUsers)
            if (a.Email == email && a.Password == password)
            {
                return a;
            }
        return null;
    }
}