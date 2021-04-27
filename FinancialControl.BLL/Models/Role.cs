using Microsoft.AspNetCore.Identity;

namespace FinancialControl.BLL.Models
{
    public class Role : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
