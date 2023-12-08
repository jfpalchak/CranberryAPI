using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CranberryAPI.Models;

namespace CranberryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JournalsController : ControllerBase
{
  private readonly CranberryAPIContext _db;

  public JournalsController(CranberryAPIContext db)
  {
    _db = db;
  }

  // GET: api/journals
}