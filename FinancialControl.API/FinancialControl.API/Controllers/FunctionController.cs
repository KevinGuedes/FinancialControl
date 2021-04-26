using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    public class FunctionController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
