using MessagePack;
using Microsoft.Build.Framework;

namespace Operadora.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        public string Email { get; set; }
    }
}
