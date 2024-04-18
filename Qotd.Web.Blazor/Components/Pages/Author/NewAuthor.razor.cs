using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Qotd.Shared.Model;
using Qotd.Shared.Utilities;

namespace Qotd.Web.Blazor.Components.Pages.Author;
public partial class NewAuthor
{
    [SupplyParameterFromForm]
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new();
    [Inject] public ILogger<NewAuthor> Logger { get; set; } = default!;

    private Task HandleValidSubmit(EditContext arg)
    {
        Logger.LogInformation($"Valid Submit aufgerufen... {AuthorForCreateVm?.LogAsJson()}");
        return Task.CompletedTask;
    }

    private void OnInputFileChanged(InputFileChangeEventArgs arg)
    {
        AuthorForCreateVm!.Photo = arg.File;
    }
}
