using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prog6212_part3_ST10456157.Data;
namespace prog6212_part3_ST10456157.Pages
{
    public class HrSummaryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HrSummaryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<HrSummaryVM> SummaryList { get; set; }

        public void OnGet()
        {
            var approvedClaims = _context.Claims
    .Where(c => c.Status == "Approved")
    .ToList(); // materialize in memory

            SummaryList = approvedClaims
                .GroupBy(c => c.LecturerName)
                .Select(g => new HrSummaryVM
                {
                    Lecturer = g.Key,
                    TotalPaid = g.Sum(x => x.TotalAmount) // decimal sum works in memory
                })
                .ToList();

        }

        public FileResult OnGetExport()
        {
            var claims = _context.Claims
                .Where(c => c.Status == "Approved")
                .ToList();

            var csv = "Lecturer,TotalPaid\n";

            foreach (var group in claims.GroupBy(x => x.LecturerName))
            {
                csv += $"{group.Key},{group.Sum(x => x.TotalAmount)}\n";
            }

            return File(
                new System.Text.UTF8Encoding().GetBytes(csv),
                "text/csv",
                "HR_Summary.csv"
            );
        }
    }

    public class HrSummaryVM
    {
        public string Lecturer { get; set; }
        public decimal TotalPaid { get; set; }
    }
}

