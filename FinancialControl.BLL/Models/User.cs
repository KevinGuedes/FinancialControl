using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinancialControl.BLL.Models
{
    public class User : IdentityUser<string>
    {
        public string TaxNumber { get; set; }

        public string Occupation { get; set; }

        public byte[] Photograph { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Profit> Profits { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
