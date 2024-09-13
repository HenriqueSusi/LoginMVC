using CadastroMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static CadastroMvc.Areas.Identity.Pages.Account.RegisterModel;

namespace CadastroMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Ignore<AuthenticationScheme>();


            builder.Entity<ApplicationUser>()
            .HasOne(a => a.Cliente)   
            .WithOne(c => c.Usuario)  
            .HasForeignKey<ApplicationUser>(a => a.IdCliente);  
        }
        public DbSet<CadastroMvc.Models.ClienteModel> ClienteModel { get; set; } = default!;
    }
}