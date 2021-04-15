using System.Collections.Generic;

namespace FinancialControl.BLL.Models
{
    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
