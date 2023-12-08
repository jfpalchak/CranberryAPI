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
  private readonly CranberryAPIContext _db;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;
  private readonly IConfiguration _configuration;

  public UsersController(CranberryAPIContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
  {
    _db = db;
    _userManager = userManager;
    _signInManager = signInManager;
    _configuration = configuration;
  }

  // ## # # # # # # # # # # # # # # ##
  // # USER AUTHENTICATION ENDPOINTS #
  // ## # # # # # # # # # # # # # # ##

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

  // POST: api/users/signin
  [HttpPost("signin")]
  public async Task<IActionResult> SignIn(SignInDto userInfo) 
  {
    ApplicationUser user = await _userManager.FindByEmailAsync(userInfo.Email);

    if (user != null)
    {
      var signInResult = await _signInManager.PasswordSignInAsync(user, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
      if (signInResult.Succeeded)
      {
        List<Claim> authClaims = new List<Claim>
        {
          new Claim("userId", user.Id),
          new Claim("userName", user.UserName)
        };

        var newToken = CreateToken(authClaims);

        return Ok(new { status = "Success", message = $"{userInfo.Email} signed in.", token = newToken });
      }
    }

    return BadRequest(new { status = "Error", message = "Unable to sign in." });
  }

  // Generate a user's Token
  private string CreateToken(List<Claim> authClaims)
  {
    SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

    JwtSecurityToken token = new JwtSecurityToken(
      issuer: _configuration["JWT:ValidIssuer"],
      audience: _configuration["JWT:ValidAudience"],
      expires: DateTime.Now.AddHours(12),
      claims: authClaims,
      signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );

    // Serialize and return our newly created Token:
    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  // ## # # # # # # # # # # # ##
  // # USER CRUD ENDPOINTS  #
  // ## # # # # # # # # # # # ##

  // GET: api/users/{id}
  // public async Task<ActionResult<List<Claim>>> GetUserData(string id) {

  //   ApplicationUser user = await _userManager.FindByIdAsync(id);

  //   if (user == null)
  //   {
  //     return NotFound();
  //   }

  // }

  // PUT: api/users/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(string id, UpdateUserModel userModel)
  {
    ApplicationUser user = await _userManager.FindByIdAsync(id);
    if (user == null)
    {
      return NotFound();
    }
    
    // Error handling & Validation Checking should go here
    // will update information to 0 if information is not present in request
    if (userModel.AvgSmokedDaily != user.AvgSmokedDaily)
    {
      user.AvgSmokedDaily = userModel.AvgSmokedDaily;
    }
    if (userModel.CigsPerPack != user.CigsPerPack)
    {
      user.CigsPerPack = userModel.CigsPerPack;
    }
    if (userModel.PricePerPack != user.PricePerPack)
    {
      user.PricePerPack = userModel.PricePerPack;
    }
    if (userModel.QuitDate != user.QuitDate)
    {
      user.QuitDate = userModel.QuitDate;
    }

    IdentityResult result = await _userManager.UpdateAsync(user);

    if (result.Succeeded)
    {
      return NoContent();
    }
    else
    {
      return BadRequest(result.Errors);
    }
  }
  
  // DELETE: api/users/{id}

  // ## # # # # # # # # # # # ##
  // # USER JOURNAL ENDPOINTS  #
  // ## # # # # # # # # # # # ##

  // GET: api/users/{id}/journals
  [HttpGet("{id}/journals")]
  // [Authorize]
  public async Task<ActionResult<IEnumerable<Journal>>> GetUserJournals(string id)
  {
    List<Journal> userJournals = await _db.Journals.Where(j => j.UserId == id).ToListAsync();

    return Ok(userJournals);
  }

  // GET: api/users/{id}/journals/{id}
  [HttpGet("{id}/journals/{journalId}")]
  // [Authorize]
  public async Task<IActionResult> GetUserJournal(string id, int journalId)
  {
    Journal journal = await _db.Journals.FirstOrDefaultAsync(journal => journal.JournalId == journalId && journal.UserId == id);

    return Ok(journal);
  }

  // POST: api/users/{id}/journals
  [HttpPost("{id}/journals")]
  // [Authorize]
  public async Task<ActionResult<Journal>> PostJournal(string id, Journal journal)
  {
    journal.UserId = id;
    journal.Date = DateTime.Now; // unless we let user specify the date
    _db.Journals.Add(journal);
    await _db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetUserJournal), new { id = id, journalId = journal.JournalId }, journal);
  }

  // PUT: api/users/{id}/journals/{id}

  // DELETE: api/users/{id}/journals/{id}
}
