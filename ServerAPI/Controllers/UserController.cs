using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private IUserRepository FakeUserRepository;

    // Dependency injection. Constructor til funktionen ovenfor
    public UserController(IUserRepository userRepository)
    {
        this.FakeUserRepository = userRepository;
    }

    [HttpGet]
    public User[] GetAll()
    {
        return FakeUserRepository.GetAll();
    }

    [HttpPost("Validate")]
    public User? Validate(string email, string password)
    {
        return FakeUserRepository.Validate(email, password);
    }
}