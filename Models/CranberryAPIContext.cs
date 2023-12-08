using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CranberryAPI.Models;

public class CranberryAPIContext : IdentityDbContext<ApplicationUser>
{
  public DbSet<Entry> Entries { get; set; }

  public CranberryAPIContext(DbContextOptions<CranberryAPIContext> options) : base(options) { }
}