using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models;

public class BookAuthor
{
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}