using Microsoft.AspNetCore.Mvc;
using NumberTwo.API.Models;
using NumberTwo.Core.Services;

namespace NumberTwo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = await _authService.RegisterAsync(registerDto.Username!, registerDto.Email!, registerDto.Password!);

        if (user == null)
            return BadRequest("Registration Failed");

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _authService.LoginAsync(loginDto.Email!, loginDto.Password!);

        if (user == null)
            return Unauthorized();

        return Ok(user);
    }

}
