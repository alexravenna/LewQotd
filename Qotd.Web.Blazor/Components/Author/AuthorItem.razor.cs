using Microsoft.AspNetCore.Components;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Author;
public partial class AuthorItem
{
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }

    [Parameter]
    public EventCallback<Guid> OnAuthorDeleteCallback { get; set; } // On + Entit�t + Aktion + Callback

    private async Task DeleteAuthor(Guid authorId)
    {
        await OnAuthorDeleteCallback.InvokeAsync(authorId); //Ereignis ausl�sen it Parameter f�r Eltern-Componente
    }
}
