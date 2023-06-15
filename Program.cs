using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cakekue_J94824.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Cakekue_J94824Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cakekue_J94824Context") ??
    throw new InvalidOperationException("Connection string 'Cakekue_J94824Context' not found.")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<Cakekue_J94824Context>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
    options.LogoutPath = new PathString("/Index");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy",
        policy => policy.RequireRole("Administrator"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "AdminPolicy");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


