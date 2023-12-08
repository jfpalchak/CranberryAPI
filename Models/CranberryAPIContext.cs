using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CranberryAPI.Models;

public class CranberryAPIContext : IdentityDbContext<ApplicationUser>
{
  public DbSet<Journal> Journals { get; set; }

  public CranberryAPIContext(DbContextOptions<CranberryAPIContext> options) : base(options) { }
}