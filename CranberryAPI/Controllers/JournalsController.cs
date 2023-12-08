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
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Journal>>> Get() 
  {
    IQueryable<Journal> query = _db.Journals.AsQueryable();

    // ########################
    // # BASIC PAGINATION:
    // # search params: 
    // # int page = 1, int pageSize = 2
    // # declare our skip argument:
    // # int skip = (page - 1) * pageSize;
    // # add Skip and Take to query:
    // # query.Skip(skip).Take(pageSize);

    return await query.ToListAsync();
  }


  // GET: api/journals/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Journal>> GetJournal(int id)
  {
    Journal journal = await _db.Journals
                                  .Include(journal => journal.User)
                                  .FirstOrDefaultAsync(journal => journal.JournalId == id);

    if (journal == null)
    {
      return NotFound();
    }

    return journal;
  }

  // POST: api/journals
  [HttpPost]
  // [Authorize]
  public async Task<ActionResult<Journal>> Post(Journal journal)
  {
    _db.Journals.Add(journal);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetJournal), new { id = journal.JournalId }, journal);
  }

  // PUT: api/journals/{id}
  [HttpPut("{id}")]
  // [Authorize]
  public async Task<IActionResult> Put(int id, Journal journal)
  {
    if (id != journal.JournalId)
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
      if (!JournalExists(id))
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

  // DELETE: api/journals/{id}
  [HttpDelete("{id}")]
  // [Authorize]
  public async Task<IActionResult> DeleteJournal(int id)
  {
    Journal journal = await _db.Journals.FindAsync(id);
    if (journal == null)
    {
      return NotFound();
    }

    _db.Journals.Remove(journal);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}