using BookManager.Application.Enums;
using BookManager.Application.Response;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateReturnBook
{
    public class CreateReturnBookCommandHandler : IRequestHandler<CreateReturnBookCommand, ReturnBookResponse>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;


        public CreateReturnBookCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<ReturnBookResponse> Handle(CreateReturnBookCommand request, CancellationToken cancellationToken)
        {
            var bookLoan = await _loanRepository.GetLoanByUserAndBook(request.UserId, request.BookId);

            if (bookLoan == null)
            {
                throw new Exception("not found");
            }

            var book = await _bookRepository.GetBookById(bookLoan.BookId);

            if (book == null || book.Status != Enums.BookStatus.Borrowed)
            {
                throw new Exception("The book is not borrowed");
            }

            var daysLate = 0;

            if (bookLoan.ReturnDate < DateTime.Now)
            {
                daysLate = (DateTime.Now - bookLoan.ReturnDate).Days;
            }

            book.Status = BookStatus.Available;
            await _bookRepository.UpdateBook(book);

            await _loanRepository.RemoveLoan(bookLoan);

            return new ReturnBookResponse
            {
                Success = true,
                DaysLate = daysLate,
                Message = daysLate > 0 ? $"The book is {daysLate} days late." : "The book was returned on time."
            };
        }
    }
}
