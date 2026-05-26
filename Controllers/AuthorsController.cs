using AutoMapper;
using BookApi.Data;
using BookApi.DTOs;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(AppDbContext db, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
    {
        var authors = await db.Authors
            .Include(a => a.BookAuthors)
            .ThenInclude(ba => ba.Book)
            .ToListAsync();

        return Ok(mapper.Map<IEnumerable<AuthorDto>>(authors));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetById(int id)
    {
        var author = await db.Authors
            .Include(a => a.BookAuthors)
            .ThenInclude(ba => ba.Book)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (author is null) return NotFound();
        return Ok(mapper.Map<AuthorDto>(author));
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> Create(CreateAuthorDto dto)
    {
        var author = mapper.Map<Author>(dto);
        db.Authors.Add(author);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById),
            new { id = author.Id }, mapper.Map<AuthorDto>(author));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateAuthorDto dto)
    {
        var author = await db.Authors.FindAsync(id);
        if (author is null) return NotFound();

        mapper.Map(dto, author);
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await db.Authors.FindAsync(id);
        if (author is null) return NotFound();

        db.Authors.Remove(author);
        await db.SaveChangesAsync();
        return NoContent();
    }
}