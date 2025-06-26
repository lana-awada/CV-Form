using homework5_CV.Data;
using homework5_CV.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

/*builder.Services.AddScoped<CVservices>();*/
builder.Services.AddScoped<ICVservices, CVservices>();// kenet 7atta hyde ma kenet tozbat leh? laeno lama kenet aarefun bl .cshtml.cs keno CVservices bsbs eza 7atayta ICVservices b7ot hon hyde
/*builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson();*///hyde kermel to pass data btw cvpage w cvsummary nazalet nuget package Microsoft.AspNetCore.Mvc.NewtonsoftJson
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LogIn";
        options.AccessDeniedPath = "/AccessDenied"; // optional
    });


var app = builder.Build();

app.UseAuthentication(); // before UseAuthorization
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
