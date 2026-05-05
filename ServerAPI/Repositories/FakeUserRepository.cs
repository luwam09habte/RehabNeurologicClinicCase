using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeUserRepository : IUserRepository
{
    private List<User> fUsers =
    [
        new User() { UserId = 1, Name = "Admin1", Password = "Hans123", Email = "Hans123@gmail.com", Role = "Admin" },
        new User() { UserId = 2, Name = "Patient1", Password = "Peter123", Email = "Peter123@gmail.com", Role = "Patient" },
        new User() { UserId = 3, Name = "Patient2", Password = "Lars123", Email = "Lars123@gmail.com", Role = "Patient" }
    ];

    public User[] GetAll()
    {
        return fUsers.ToArray();
    }

    public User? Validate(string email, string password)
    {
        foreach (User u in fUsers)
            if (u.Email == email && u.Password == password)
            {
                return u;
            }

        return null;
    }
}