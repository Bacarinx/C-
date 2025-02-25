using TechLibrary.API.Infrastructure.Context;
using TechLibrary.API.Services.LoggedUser;
using TechLibrary.Exception;

namespace TechLibrary.API.UseCases.Checkout
{
    public class CheckoutBookUseCase
    {
        private readonly HttpContext _Context;
        public CheckoutBookUseCase(HttpContext context)
        {
            _Context = context;
        }

        public void Execute(Guid bookId)
        {
            var context = new TechLibraryDbContext();

            var loggedUser = new LoggedUserService(_Context);
            var user = loggedUser.getUser(context);

            Validate(context, bookId);

            context.Checkouts.Add(new Entities.Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(7)
            });

            context.SaveChanges();
        }

        private void Validate(TechLibraryDbContext context, Guid bookId)
        {
            var book = context.Books.FirstOrDefault(book => book.Id == bookId);

            if(book is null)
            {
                throw new NotFoundException("Não há livros com esse Id");
            }

            var booksNotReturned = context.Checkouts.Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if(booksNotReturned == book.Amount)
            {
                throw new ConflictException("Esse livro não está disponível para empréstimo!");
            }
        }
    }
}
