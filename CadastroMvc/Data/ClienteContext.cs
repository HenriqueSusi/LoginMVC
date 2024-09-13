using CadastroMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroMvc.Data
{
   
        public class ClienteContext : DbContext
        {
            public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

            public DbSet<ApplicationUser> Clientes { get; set; }

        }

}
