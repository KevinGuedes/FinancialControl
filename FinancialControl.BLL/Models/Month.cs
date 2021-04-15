using System.Collections.Generic;

namespace FinancialControl.BLL.Models
{
    public class Month
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }

        public virtual ICollection<Profit> Profits { get; set; }
    }
}
