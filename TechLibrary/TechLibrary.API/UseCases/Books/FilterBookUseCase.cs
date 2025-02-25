using TechLibrary.API.Infrastructure.Context;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;

namespace TechLibrary.API.UseCases.Books
{
    public class FilterBookUseCase
    {
        private const int _CountSkip = 10;
        public ResponseBooks Execute(RequestBookFilter request)
        {
            var context = new TechLibraryDbContext();

            var query = context.Books.AsQueryable();
            if(!string.IsNullOrWhiteSpace(request.BookName))
                query = query.Where(book => book.Title.Contains(request.BookName));

            var result = query.
                         OrderBy(book => book.Title).
                         ThenBy(book => book.Author).
                         Skip(_CountSkip * (request.PageNumber - 1)).
                         Take(_CountSkip).
                         ToList();

            return new ResponseBooks
            {
                Pagination = request.PageNumber,
                Books = result.Select(book => new ResponseBook
                {
                    BookId = book.Id,
                    AuthorName = book.Author,
                    Name = book.Title
                }).ToList()
            };
        }
    }
}
