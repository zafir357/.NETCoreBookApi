using System.ComponentModel.DataAnnotations;

namespace BookApi.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    // One publisher → many books
    public ICollection<Book> Books { get; set; } = [];
}