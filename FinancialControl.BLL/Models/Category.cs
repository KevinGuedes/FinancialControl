using System.Collections.Generic;

namespace FinancialControl.BLL.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }

        public virtual ICollection<Profit> Profits { get; set; }
    }
}
