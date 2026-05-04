using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeUserRepository : IUserRepository
{
    private List<User> fUsers =
    [
        new User() { UserId = 1, Name = "Hans", Password = "Hans123", Email = "Hans123@gmail.com" },
        new User() { UserId = 2, Name = "Peter", Password = "Peter123", Email = "Peter123@gmail.com" },
        new User() { UserId = 3, Name = "Lars", Password = "Lars123", Email = "Lars123@gmail.com" }
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