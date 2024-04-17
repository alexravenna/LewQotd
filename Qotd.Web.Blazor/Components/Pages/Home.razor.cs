using Microsoft.AspNetCore.Components;
using Qotd.Data.Context;
using Qotd.Service;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Pages;

public partial class Home
{
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    [Inject]
    public IQotdService QotdService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    }
}
