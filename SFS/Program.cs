using Microsoft.EntityFrameworkCore;
using SFS.Data;
using Microsoft.AspNetCore.Identity;
using SFS.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//database connectioin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();

// Ensure roles are seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRoles.SeedRolesAsync(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


// Map default controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Client}/{controller=Home}/{action=Index}/{id?}");



// Map Razor Pages (including Identity)
app.MapRazorPages();


app.Run();
