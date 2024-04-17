namespace Qotd.Shared.Model;

public class QuoteViewModel
{
    public Guid Id { get; set; }
    public required string QuoteText { get; set; }
    public string? AuthorName { get; set; }
}