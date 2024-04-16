using Microsoft.AspNetCore.Components;
using Qotd.Data.Context;
using Qotd.Shared.Model;

namespace Qotd.Web.Blazor.Components.Pages;
public partial class Home
{
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    [Inject]
    public QotdContext QotdContext { get; set; } = default!;

    protected override void OnInitialized()
    {
        var authors = QotdContext.Authors.ToList();

        QotdViewModel = new QuoteOfTheDayViewModel
        {
            AuthorBirthDate = new DateOnly(2024, 04, 16),
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            QuoteText = "Larum lierum Löffelstiel, wer nicht fragt der weiß nicht viel"
        };
    }
}
