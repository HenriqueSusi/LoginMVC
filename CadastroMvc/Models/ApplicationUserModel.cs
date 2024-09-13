using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CadastroMvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public Teste Teste { get; set; }
    }

    public class Cliente : ApplicationUser
    {
        public Guid Id { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set;}
        public string Email { get; set; }
        public ApplicationUser Usuario { get; set; }

    }

    public class Funcionario : ApplicationUser
    {
        public Guid IdFunc { get; set; }
        public string Nome { get; set; }
        public string CPNJ { get; set; }
        public string Senha { get; set;}
        public string Email { get; set;}
        
    }

    public class Teste : ApplicationUser
    {
        public string NomeTeste { get; set; }


    }
}
