using Microsoft.AspNetCore.Identity;

namespace FinancialControl.BLL.Models
{
    public class Function : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
