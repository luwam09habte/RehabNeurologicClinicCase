using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController
{
    private IAdminRepository FakeAdminRepository;

    // Dependency injection. Constructor til funktionen ovenfor
    public AdminController(IAdminRepository adminRepository)
    {
        this.FakeAdminRepository = adminRepository;
    }
    
    [HttpGet]
    public Admin[] GetAll()
    {
        return FakeAdminRepository.GetAll();
    }

    [HttpPost("Validate")]
    public Admin? Validate(string email, string password)
    {
        return FakeAdminRepository.Validate(email, password);
    }
}