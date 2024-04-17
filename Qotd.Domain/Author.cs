using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qotd.Domain;

//[Table("blablubb")]
public class Author : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public virtual IList<Quote> Quotes { get; set; } = new List<Quote>();
    public byte[]? Photo { get; set; }
    public string? PhotoMimeType { get; set; }
}