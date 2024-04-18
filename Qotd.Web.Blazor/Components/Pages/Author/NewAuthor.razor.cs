using Microsoft.AspNetCore.Components;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Pages.Author;
public partial class NewAuthor
{
    [SupplyParameterFromForm]
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new();
}
