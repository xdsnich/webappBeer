namespace WebAppbotbeer.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int TelegramId { get; set; } 
        public string FirstName { get; set; }  =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int TotalScore { get; set; } = 200;
        public string Hash { get; set; }
        public string PhotoUrl {  get; set; } = string.Empty;
        public long AuthDate { get; set; } 
        //public ICollection<DrinkEntry>? DrinkEntries { get; set; }
    }
}
