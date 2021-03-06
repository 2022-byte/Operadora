using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Operadora.Models
{
    public class Cliente
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdCliente { get; set; }
        [Microsoft.Build.Framework.Required]
        public string NomeCliente { get; set; }
        public string Email { get; set; }
    }
}
