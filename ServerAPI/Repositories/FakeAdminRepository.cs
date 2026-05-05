using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeAdminRepository : IAdminRepository
{
    private List<Admin> fAdmins =
    [
        new Admin() { AdminId = 1, Name = "Admin", Password = "Admin123", Email = "Admin1", Role = "Admin" },
    ];

    public Admin[] GetAll()
    {
        return fAdmins.ToArray();
    }

    public Admin? Validate(string email, string password)
    {
        foreach (Admin a in fAdmins)
            if (a.Email == email && a.Password == password)
            {
                return a;
            }
        return null;
    }
}