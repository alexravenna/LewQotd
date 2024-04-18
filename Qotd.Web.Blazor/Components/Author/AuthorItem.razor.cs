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
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; } // On + Entit�t + Aktion + Callback

    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;

    public ConfirmDialog? ConfirmDialogComponent { get; set; }


    private async Task DeleteAuthor(Guid authorId)
    {
        //1.Version Klassik
        //if (await JsRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor {AuthorVm?.Name} l�schen?"))
        //{
        //    await OnAuthorDeleteCallback.InvokeAsync(authorId); //Ereignis ausl�sen it Parameter f�r Eltern-Componente
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
