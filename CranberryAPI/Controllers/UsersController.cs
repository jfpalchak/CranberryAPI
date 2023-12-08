using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using CranberryAPI.Models;

namespace CranberryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;
  private readonly IConfiguration _configuration;

  public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _configuration = configuration;
  }

  // POST: api/users/register
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto user)
  {
    // Check if these credentials have already been registered.
    // If so, return error; otherwise continue.
    ApplicationUser userExists = await _userManager.FindByEmailAsync(user.Email);
    if (userExists != null)
    {
      return BadRequest(new { status = "Error", message = "Email is already registered." });
    }

    ApplicationUser newUser = new ApplicationUser() { Email = user.Email, UserName = user.UserName};
    IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

    if (result.Succeeded)
    {
      return Ok(new { status = "Success", message = $"User {user.UserName} has been successfully created." });
    }
    else
    {
      return BadRequest(result.Errors);
    }
  }
}
