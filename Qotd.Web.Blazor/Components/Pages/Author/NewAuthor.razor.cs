using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Qotd.Service;
using Qotd.Shared.Model;
using Qotd.Shared.Utilities;

namespace Qotd.Web.Blazor.Components.Pages.Author;

public partial class NewAuthor
{
    [SupplyParameterFromForm]
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new();

    [Inject]
    public ILogger<NewAuthor> Logger { get; set; } = default!;

    [Inject] public IQotdService QotdService { get; set; } = default!;
    [Inject] public NavigationManager NavManager { get; set; } = default!;

    private async Task HandleValidSubmit(EditContext arg)
    {
        Logger.LogInformation($"Valid submit aufgerufen...{AuthorForCreateVm?.LogAsJson()}");

        var added = await QotdService.AddAuthorAsync(AuthorForCreateVm);
        if (added)
        {
            NavManager.NavigateTo("/authors/overview");
        }
    }

    private void OnInputFileChanged(InputFileChangeEventArgs arg)
    {
        AuthorForCreateVm!.Photo = arg.File;
    }
}
