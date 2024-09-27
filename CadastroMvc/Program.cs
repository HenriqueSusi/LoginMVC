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

// Configuração de serviços
builder.Services.AddControllersWithViews();

// Adiciona suporte para sessão
builder.Services.AddDistributedMemoryCache();  // Cache distribuído para sessões
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tempo limite da sessão
    options.Cookie.HttpOnly = true;  // Somente acessível via HTTP
    options.Cookie.IsEssential = true;  // Necessário para que a sessão funcione
});

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Página de erro detalhada para desenvolvedores
}
else
{
    app.UseExceptionHandler("/Home/Error");  // Página de erro genérica
    app.UseHsts();  // Reforça o uso de HTTPS
}

app.UseHttpsRedirection();  // Redireciona HTTP para HTTPS
app.UseStaticFiles();  // Ativa arquivos estáticos, como CSS e JavaScript

app.UseRouting();  // Habilita roteamento

app.UseSession();  // Ativa a sessão
app.UseAuthentication();  // Autenticação (se estiver configurada)
app.UseAuthorization();  // Autorização baseada em roles/permissões

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Rota padrão


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

