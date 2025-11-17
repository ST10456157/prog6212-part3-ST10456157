using Microsoft.AspNetCore.Mvc;
using prog6212_part3_ST10456157.Data;

namespace prog6212_part3_ST10456157.Controllers
{
    public class HrController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HrController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ApprovedClaims()
        {
            return View(_context.Claims.Where(c => c.Status == "Approved").ToList());
        }
    }

}
