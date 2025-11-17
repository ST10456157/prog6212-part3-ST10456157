using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prog6212_part3_ST10456157.Models;
using prog6212_part3_ST10456157.Data;


namespace prog6212_part3_ST10456157.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LecturerController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitClaim(prog6212_part3_ST10456157.Models.LecturerClaim model, IFormFile? file)
        {
            try
            {
                

                // AUTO-CALCULATE
                model.TotalAmount = model.HoursWorked * model.HourlyRate;
                model.DateSubmitted = DateTime.Now;

                // FILE UPLOAD VALIDATION
                if (file != null && file.Length > 0)
                {
                    var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx", ".jpg", ".jpeg", ".png" };
                    var ext = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(ext))
                    {
                        TempData["Error"] = $"File type '{ext}' is not supported.";
                        return RedirectToAction("Index");
                    }

                    var uploads = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    var safeFileName = Guid.NewGuid().ToString() + ext;
                    var filePath = Path.Combine(uploads, safeFileName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }

                    model.DocumentName = safeFileName;    
                }

                model.Status = "Pending";

                _context.Claims.Add(model);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Claim submitted successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Unexpected error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
