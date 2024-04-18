using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Qotd.ComponentsLibrary;
using Qotd.Domain;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Author;
public partial class AuthorItem
{
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }

    [Parameter]
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; } // On + Entität + Aktion + Callback

    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

    public ConfirmDialog? ConfirmDialogComponent { get; set; }


    private async Task DeleteAuthor(Guid authorId)
    {
        //1.Version Klassik
        //if (await JsRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor {AuthorVm?.Name} löschen?"))
        //{
        //    await OnAuthorDeleteCallback.InvokeAsync(authorId); //Ereignis auslösen it Parameter für Eltern-Componente
        //}

        //2. Version als Componente
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
