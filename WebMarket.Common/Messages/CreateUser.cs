namespace WebMarket.Common.Messages
{
    public class CreateUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
