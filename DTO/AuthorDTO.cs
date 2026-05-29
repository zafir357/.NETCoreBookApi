namespace BookApi.DTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public List<BookSummaryDto> Books { get; set; } = [];
}

public class BookSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
}

public class CreateAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}

public class UpdateAuthorBooksDto
{
    public List<int> BookIds { get; set; } = [];
}