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
        await GetAuthorsAsync();
    }

    private async Task GetAuthorsAsync()
    {
        AuthorsVm = await QotdService.GetAuthorsAsync();
    }

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Autor löschen aufgerufen mit Id: {authorId}");
        
        var isDeleted = await QotdService.DeleteAuthorAsync(authorId);

        if (isDeleted)
        {
            await GetAuthorsAsync();
        } else
        {
            Logger.LogError($"Autor mit der Id: {authorId} konnte NICHT gelöscht werden");
        }
    }
}
