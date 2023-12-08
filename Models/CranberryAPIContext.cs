using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CranberryAPI.Models;

public class CranberryAPIContext : IdentityDbContext<ApplicationUser>
{
  
}