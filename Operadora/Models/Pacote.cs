using System.ComponentModel.DataAnnotations;

namespace Operadora.Models;

public class Pacote
{
    [Key]
    public int IdPacote { get; set; }
    [Required]
    public string NomePacote { get; set; }
    public string ConteudoPacote { get; set; }
    public DateTime CreatedData { get; set; } 
}