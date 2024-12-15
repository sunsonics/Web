using Microsoft.EntityFrameworkCore;
using Web.Data;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);   
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true;  
});

 
builder.Services.AddRazorPages();

 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

 
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

 
app.UseSession();   

app.UseAuthorization();

app.MapRazorPages();

app.Run();


