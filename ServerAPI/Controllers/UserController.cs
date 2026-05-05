using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

public class UserController
{
    private IUserRepository FakeUserRepository;

    public UserController(IUserRepository userRepository)
    {
        this.FakeUserRepository = userRepository;
    }

    [HttpGet]
    public User[] GetAll()
    {
        return FakeUserRepository.GetAll();
    }

    [HttpPost]
    public User? Validate(string email, string password)
    {
        return FakeUserRepository.Validate(email, password);
    }
}