using Qotd.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qotd.Service;

public interface IQotdService
{
    Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
    Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync();
    Task<bool> DeleteAuthorAsync(Guid authorId);
    Task<bool> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel);
}