using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Operadora.Models
{
    public class Operador
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdOperador { get; set; }
        [Microsoft.Build.Framework.Required]
        public string NomeOperador { get; set; }

        public string EmailOperador { get; set; }
    }
}
