namespace BookManager.Application.Response
{
    public class LoginResponse
    {
        public LoginResponse(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
