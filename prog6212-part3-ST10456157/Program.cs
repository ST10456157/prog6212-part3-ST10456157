using Microsoft.EntityFrameworkCore;
using prog6212_part3_ST10456157.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Add Razor Pages support
builder.Services.AddRazorPages();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages
app.MapRazorPages();  // <-- This line enables Razor Pages

app.Run();




