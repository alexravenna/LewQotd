using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Author;
public partial class AuthorItem
{
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }

    [Parameter]
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; } // On + Entität + Aktion + Callback

    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;


    private async Task DeleteAuthor(Guid authorId)
    {
        //1.Version Klassik
        if (await JsRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor {AuthorVm?.Name} löschen?"))
        {
            await OnAuthorDeleteCallback.InvokeAsync(authorId); //Ereignis auslösen it Parameter für Eltern-Componente
        }

    }
}
