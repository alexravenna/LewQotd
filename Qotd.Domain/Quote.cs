using System.ComponentModel.DataAnnotations.Schema;

namespace Qotd.Domain;

public class Quote : BaseEntity
{
    public required string QuoteText { get; set; }

    //[ForeignKey("Krustenbraten")]
    public virtual Author Author { get; set; }
    public Guid AuthorId { get; set; }  //public Guid Krustenbraten { get; set; }
}