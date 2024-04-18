using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qotd.Shared.Model;

public class AuthorForCreateViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public IBrowserFile? Photo { get; set; }
}