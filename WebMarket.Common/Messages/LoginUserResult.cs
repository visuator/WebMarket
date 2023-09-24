namespace WebMarket.Common.Messages
{
    public class LoginUserResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
