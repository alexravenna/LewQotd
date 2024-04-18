using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Author;
public partial class AuthorItem
{
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }

    [Parameter]
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; } // On + Entit�t + Aktion + Callback

    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;


    private async Task DeleteAuthor(Guid authorId)
    {
        //1.Version Klassik
        if (await JsRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor {AuthorVm?.Name} l�schen?"))
        {
            await OnAuthorDeleteCallback.InvokeAsync(authorId); //Ereignis ausl�sen it Parameter f�r Eltern-Componente
        }

    }
}
