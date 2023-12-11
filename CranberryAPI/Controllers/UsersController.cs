using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using CranberryAPI.Models;
using CranberryAPI.Wrappers;

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

        return Ok(new { status = "Success", message = $"{userInfo.Email} signed in.", token = newToken, userId = user.Id });
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

  // ## # # # # # # # # # # ##
  // #  USER CRUD ENDPOINTS  #
  // ## # # # # # # # # # # ##

  // GET: api/users/{id}
  [HttpGet("{id}")]
  [Authorize]
  public async Task<ActionResult> GetUserData(string id) {

    string currentUserId = User.FindFirst("userId")?.Value;
    ApplicationUser user = await _userManager.FindByIdAsync(id);

    // check if requested user exists, 
    // or if the client isn't requesting their own information
    if (user == null || currentUserId != id)
    {
      return NotFound();
    }

    UserProfileDto userDto = new()
    {
      UserId = user.Id,
      UserName = user.UserName,
      QuitDate = user.QuitDate,
      AvgSmokedDaily = user.AvgSmokedDaily,
      PricePerPack = user.PricePerPack,
      CigsPerPack = user.CigsPerPack,
      // Journals = user.Journals
    };

    var response = new Response<UserProfileDto> {
      Status = "Success",
      Message = "User info retrieved successfully.",
      Data = userDto
    };

    return Ok(response);

  }

  // GET: api/users/profile
  // [HttpGet("profile")]
  // [Authorize]
  // public async Task<ActionResult> GetUserProfile() {

  //   // grab the user's id from the JWT
  //   string currentUserId = User.FindFirst("userId")?.Value;
  
  //   ApplicationUser user = await _userManager.FindByIdAsync(currentUserId);

  //   if (user == null)
  //   {
  //     return NotFound();
  //   }

  //   UserProfileDto userDto = new()
  //   {
  //     UserId = user.Id,
  //     UserName = user.UserName,
  //     QuitDate = user.QuitDate,
  //     AvgSmokedDaily = user.AvgSmokedDaily,
  //     PricePerPack = user.PricePerPack,
  //     CigsPerPack = user.CigsPerPack,
  //     // Journals = user.Journals
  //   };

  //   return Ok(userDto);
  // }

  // PUT: api/users/{id}
  [HttpPut("{id}")]
  [Authorize]
  public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto userModel)
  {
    ApplicationUser user = await _userManager.FindByIdAsync(id);
    string currentUserId = User.FindFirst("userId")?.Value;

    if (user == null || currentUserId != id)
    {
      return NotFound();
    }
    
    // Error handling & Validation Checking should go here
    // For now: if information is left out of the Put request body,
    // do not update it
    if (userModel.AvgSmokedDaily != default)
    {
      user.AvgSmokedDaily = userModel.AvgSmokedDaily;
    }
    if (userModel.CigsPerPack != default)
    {
      user.CigsPerPack = userModel.CigsPerPack;
    }
    if (userModel.PricePerPack != default)
    {
      user.PricePerPack = userModel.PricePerPack;
    }
    if (userModel.QuitDate != default)
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
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> DeleteUser(string id)
  {

    // Get the ID of the authenticated user:
    string currentUserId = User.FindFirst("userId")?.Value;

    if (currentUserId != id)
    { // instead of forbid, just don't acknowledge the data exists
      return NotFound();
    }

    ApplicationUser user = await _userManager.FindByIdAsync(id);

    if (user != null)
    {
      IdentityResult result = await _userManager.DeleteAsync(user);
      if (result.Succeeded)
      {
        return NoContent();
      }
      else
      {
        return BadRequest(result.Errors);
      }
    }
    else
    {
      return NotFound();
    }
  }

  // ## # # # # # # # # # # # ##
  // # USER JOURNAL ENDPOINTS  #
  // ## # # # # # # # # # # # ##

  // GET: api/users/{id}/journals
  [HttpGet("{id}/journals")]
  [Authorize]
  public async Task<ActionResult<IEnumerable<Journal>>> GetUserJournals(string id)
  {
    List<Journal> userJournals = await _db.Journals.Where(j => j.UserId == id).ToListAsync();

    var response = new Response<List<Journal>> {
      Status = "Success",
      Message = "Journals retrieved successfully.",
      Data = userJournals
    };

    return Ok(response);
  }

  // GET: api/users/{id}/journals/{id}
  [HttpGet("{id}/journals/{journalId}")]
  [Authorize]
  public async Task<IActionResult> GetUserJournal(string id, int journalId)
  {
    // Make sure it's the client making the request
    string currentUserId = User.FindFirst("userId")?.Value;
    if (currentUserId != id)
    { 
      return NotFound();
    }
    
    Journal journal = await _db.Journals.FirstOrDefaultAsync(journal => journal.JournalId == journalId && journal.UserId == id);
    if (journal == null) 
    {
      return NotFound();
    }

    var response = new Response<Journal> {
      Status = "Success",
      Message = "Journal retrieved successfully.",
      Data = journal
    };

    return Ok(response);
  }

  // POST: api/users/{id}/journals
  [HttpPost("{id}/journals")]
  [Authorize]
  public async Task<ActionResult<Journal>> PostJournal(string id, Journal journal)
  {
    // Make sure it's the client making the request
    string currentUserId = User.FindFirst("userId")?.Value;
    if (currentUserId != id)
    { 
      return Forbid();
    }

    journal.UserId = id;
    journal.Date = DateTime.Now; // unless we let user specify the date
    _db.Journals.Add(journal);
    await _db.SaveChangesAsync();

    var response = new Response<Journal> {
      Status = "Success",
      Message = "Journal created successfully.",
      Data = journal
    };

    return CreatedAtAction(nameof(GetUserJournal), new { id = id, journalId = journal.JournalId }, response);
  }

  // PUT: api/users/{id}/journals/{id}
  [HttpPut("{id}/journals/{journalId}")]
  [Authorize]
  public async Task<ActionResult> UpdateJournal(string id, int journalId, [FromBody] Journal journal)
  {
    // Make sure it's the client making the request
    string currentUserId = User.FindFirst("userId")?.Value;
    if (currentUserId != id)
    { 
      return Forbid();
    }
    if (journalId != journal.JournalId || id != journal.UserId)
    {
      return BadRequest();
    }
  
    _db.Journals.Update(journal);

    try 
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!JournalExists(journalId))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  private bool JournalExists(int id)
  {
    return _db.Journals.Any(j => j.JournalId == id);
  }

  // DELETE: api/users/{id}/journals/{id}
  [HttpDelete("{id}/journals/{journalId}")]
  [Authorize]
  public async Task<IActionResult> DeleteJournal(string id, int journalId)
  {
    // Make sure it's the client making the request
    string currentUserId = User.FindFirst("userId")?.Value;
    if (currentUserId != id)
    { 
      return NotFound();
    }

    Journal journal = await _db.Journals.FindAsync(journalId);

    if (journal == null)
    {
      return NotFound();
    } 
    else if (id != journal.UserId)
    {
      return BadRequest();
    }

    _db.Journals.Remove(journal);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}
