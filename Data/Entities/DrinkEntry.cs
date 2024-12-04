namespace WebAppbotbeer.Data.Entities
{
    public class DrinkEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public double Liters { get; set; } 

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

