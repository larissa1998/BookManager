namespace BookManager.Application.Response
{
    public class ReturnBookResponse
    {
        public bool Success { get; set; }
        public int DaysLate { get; set; }
        public string Message { get; set; }
    }
}
