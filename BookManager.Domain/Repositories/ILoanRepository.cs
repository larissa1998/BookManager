using BookManager.Domain.Entities;

namespace BookManager.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task CreateLoan(LoanEntity loan);
        Task RemoveLoan(LoanEntity loan);
        Task<LoanEntity> GetLoanByUserAndBook(int idUser, int idBook);
    }
}
