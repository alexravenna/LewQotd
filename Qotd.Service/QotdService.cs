using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qotd.Data.Context;
using Qotd.Shared.Model;

namespace Qotd.Service;

public class QotdService(IDbContextFactory<QotdContext> dbContextFactory) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        var quotes = await context.Quotes.Include(c => c.Author).ToListAsync();
        var random = new Random();

        var randomQuote = quotes[random.Next(0, quotes.Count)];

        return new QuoteOfTheDayViewModel
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorName = randomQuote.Author?.Name ?? string.Empty,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };
    }

    public async Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        var authors = await context.Authors.OrderBy(c => c.Name).ToListAsync();

        var authorsViewModel = authors.Select(c => new AuthorViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            BirthDate = c.BirthDate,
            Photo = c.Photo,
            PhotoMimeType = c.PhotoMimeType
        });

        return authorsViewModel;
    }

    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        var author = await context.Authors.FindAsync(authorId);

        if (author == null) return false;

        context.Authors.Remove(author);
        return await context.SaveChangesAsync() > 0;
    }
}