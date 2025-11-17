using Microsoft.AspNetCore.Mvc;
using prog6212_part3_ST10456157.Models;
using prog6212_part3_ST10456157.Data;
using ClaimModel = prog6212_part3_ST10456157.Models.LecturerClaim;


namespace prog6212_part1_ST10456157.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoordinatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PendingClaims()
        {
            var claims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(claims);
        }

        public async Task<IActionResult> Approve(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Approved";
            claim.DateVerified = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("PendingClaims");
        }

        public async Task<IActionResult> Reject(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.Status = "Rejected";
            claim.DateVerified = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("PendingClaims");
        }
    }

}
