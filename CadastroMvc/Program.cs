using CadastroMvc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CadastroMvc.Data;
using CadastroMvc.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ClienteContext>(
    options => options.UseSqlServer(connectionString)
);

// Configura��o de servi�os
builder.Services.AddControllersWithViews();

// Adiciona suporte para sess�o
builder.Services.AddDistributedMemoryCache();  // Cache distribu�do para sess�es
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tempo limite da sess�o
    options.Cookie.HttpOnly = true;  // Somente acess�vel via HTTP
    options.Cookie.IsEssential = true;  // Necess�rio para que a sess�o funcione
});

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // P�gina de erro detalhada para desenvolvedores
}
else
{
    app.UseExceptionHandler("/Home/Error");  // P�gina de erro gen�rica
    app.UseHsts();  // Refor�a o uso de HTTPS
}

app.UseHttpsRedirection();  // Redireciona HTTP para HTTPS
app.UseStaticFiles();  // Ativa arquivos est�ticos, como CSS e JavaScript

app.UseRouting();  // Habilita roteamento

app.UseSession();  // Ativa a sess�o
app.UseAuthentication();  // Autentica��o (se estiver configurada)
app.UseAuthorization();  // Autoriza��o baseada em roles/permiss�es

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Rota padr�o


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

