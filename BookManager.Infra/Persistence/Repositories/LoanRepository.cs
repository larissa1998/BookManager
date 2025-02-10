using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookManagerDbContext _dbContext;

        public LoanRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLoan(LoanEntity loan)
        {
            await _dbContext.Loan.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLoan(LoanEntity loan)
        {
            _dbContext.Loan.Remove(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LoanEntity> GetLoanByUserAndBook(int idUser, int idBook)
        {
            return await _dbContext.Loan.FirstOrDefaultAsync(i => i.UserId == idUser && i.BookId == idBook);
        }
    }
}
