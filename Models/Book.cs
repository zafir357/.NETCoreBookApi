using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }

    [ForeignKey(nameof(Publisher))]
    public int? PublisherId { get; set; }

    public Publisher? Publisher { get; set; }

    // Many-to-many navigation
    public ICollection<BookAuthor> BookAuthors { get; set; } = [];
}