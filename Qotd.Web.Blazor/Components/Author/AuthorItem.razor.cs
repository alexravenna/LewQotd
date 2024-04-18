using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Qotd.ComponentsLibrary;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Author;
public partial class AuthorItem
{
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }

    [Parameter]
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    public ConfirmDialog? ConfirmDialogComponent { get; set; }

    private async Task DeleteAuthor(Guid authorId)
    {
        //if (await JSRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor {AuthorVm?.Name} löschen?"))
        //{
        //    await OnAuthorDeleteCallback.InvokeAsync(authorId);
        //}
        ConfirmDialogComponent?.Show();
    }

    private async Task ConfirmDeleteClicked(bool deleteConfirmed)
    {
        if (deleteConfirmed)
        {
            await OnAuthorDeleteCallback.InvokeAsync(AuthorVm.Id);
        }
    }
}
