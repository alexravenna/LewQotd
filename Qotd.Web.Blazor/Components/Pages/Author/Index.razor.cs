using Microsoft.AspNetCore.Components;
using Qotd.Service;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Pages.Author;
public partial class Index
{
    [Inject] public ILogger<Index> Logger { get; set; } = default!;
    [Inject] public IQotdService QotdService { get; set; } = default!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; } = default!;

    private string _errorMessage = string.Empty;

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
        Logger.LogInformation($"Autor l�schen aufgerufen mit Id: {authorId}");

        var isDeleted = await QotdService.DeleteAuthorAsync(authorId);

        if (isDeleted)
        {
            await GetAuthorsAsync();
        }
        else
        {
            _errorMessage = $"Autor mit der Id: {authorId} konnte NICHT gel�scht werden";
            Logger.LogError(_errorMessage);
            
        }
    }
}
