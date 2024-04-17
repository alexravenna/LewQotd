using Microsoft.AspNetCore.Components;
using Qotd.Service;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Pages.Author;
public partial class Index
{
    [Inject] public ILogger<Index> Logger { get; set; } = default!;
    [Inject] public IQotdService QotdService { get; set; } = default!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        AuthorsVm = await QotdService.GetAuthorsAsync();
    }
}
