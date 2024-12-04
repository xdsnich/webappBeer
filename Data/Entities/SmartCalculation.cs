using WebAppbotbeer.Data.Enums;
namespace WebAppbotbeer.Data.Entities
{
    public class SmartCalculation
    {
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime LastDrink { get; set; }
        public int AverageBeerDrink { get; set; }
        public DrunkLevel drunkLevel { get; set; }
    }
}
