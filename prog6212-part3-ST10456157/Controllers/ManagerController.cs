using Microsoft.AspNetCore.Mvc;
using prog6212_part3_ST10456157.Models;
using prog6212_part3_ST10456157.Data;

namespace prog6212_part3_ST10456157.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AllClaims()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }

        public async Task<IActionResult> Approve(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Approved";
            claim.DateApproved = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("AllClaims");
        }
    }
      
}
