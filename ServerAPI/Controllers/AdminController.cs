using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
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

    [HttpPost("validate")]
    public Admin? Validate(string email, string password)
    {
        return FakeAdminRepository.Validate(email, password);
    }
}