using BookManager.Application.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Domain.Entities
{
    public class BookEntity
    {
        public BookEntity(string title, string author, string isbn, int year, BookStatus status)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Year = year;
            Status = status;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public int Year { get; private set; }
        public BookStatus Status { get; set; }
    }
}
