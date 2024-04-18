using Microsoft.AspNetCore.Components.Forms;
using Qotd.Shared.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Qotd.Shared.Model;

public class AuthorForCreateViewModel
{
    [Required]
    [Length(2, 50)]
    [DeniedValues(["root", "god"], ErrorMessage = "Name nicht erlaubt")]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [NoFutureDate]
    public DateOnly? BirthDate { get; set; }
    public IBrowserFile? Photo { get; set; }
}
