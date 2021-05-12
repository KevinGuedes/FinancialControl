using System.Collections.Generic;

namespace FinancialControl.BLL.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Number { get; set; }

        public double Limit { get; set; }

        public string UserId { get; set; } //Por causa do Identity, o id é do tipo string. 

        public User User { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
