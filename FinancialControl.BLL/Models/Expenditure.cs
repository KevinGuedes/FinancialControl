namespace FinancialControl.BLL.Models
{
    public class Expenditure
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public double Value { get; set; }

        public int MonthId { get; set; }

        public Month Month { get; set; }

        public int Day { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
