using BookManager.Application.Commands.DeleteBook;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Moq;

namespace BookManager.Tests.Application.Commands
{
    public class DeleteBookCommandHandlerTests
    {

        [Fact]
        public async Task InputOk_Executed_ReturnOk()
        {
            //Arrange

            var bookRepositoryMock = new Mock<IBookRepository>();

            var book = new BookEntity("Harry Potter", "JK", "12323", 2010, BookManager.Application.Enums.BookStatus.Available) { Id = 1};
            
            bookRepositoryMock.Setup(b => b.GetBookById(1)).ReturnsAsync(book);

            var deleteCommand = new DeleteBookByIdCommand(1);

            var handlerMock = new DeleteBookByIdCommandHandler(bookRepositoryMock.Object);

            //Act
            var response = handlerMock.Handle(deleteCommand, new CancellationToken());

            //Assert
            bookRepositoryMock.Verify(repo => repo.DeleteBook(It.Is<BookEntity>(b => b.Id == 1)), Times.Once);
        }
    }
}
