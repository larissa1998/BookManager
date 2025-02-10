using BookManager.Application.Enums;

namespace BookManager.Application.Response
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int Year { get; set; }
        public BookStatus Status { get; set; }
    }
}
