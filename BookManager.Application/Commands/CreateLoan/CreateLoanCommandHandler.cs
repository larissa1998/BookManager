using BookManager.Application.Enums;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.IdUser);
            var book = await _bookRepository.GetBookById(request.IdBook);

            if (user == null)
            {
                throw new Exception("User not found in the system");
            }

            if (book == null)
            {
                throw new Exception("Book not found in the system");
            }

            if (book.Status != BookStatus.Available)
            {
                throw new Exception("The book is not available for loan.");
            }

            book.Status = BookStatus.Borrowed;

            await _bookRepository.UpdateBook(book);

            var returnDate = DateTime.UtcNow.AddDays(7);

            var loan = new LoanEntity
            {
                BookId = request.IdBook,
                Id = request.IdBook,
                LoanDate = DateTime.UtcNow,
                ReturnDate = returnDate,
                UserId = request.IdUser,
            };

            await _loanRepository.CreateLoan(loan);
            
            user.Loans.Add(loan);

            await _userRepository.UpdateUser(user);

            return loan.Id;
        }
    }
}
