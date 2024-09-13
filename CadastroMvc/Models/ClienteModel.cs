using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CadastroMvc.Models
{
    public class ClienteModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Decimal Telefone { get; set; }
        public Decimal Cpf { get; set; }
        public string Email { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
