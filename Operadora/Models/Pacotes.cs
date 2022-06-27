using System.ComponentModel.DataAnnotations;

namespace Operadora.Models
{
    public abstract class Pacotes
    {
        public Pacotes(int id, string name, int displayOrder, DateTime timeCreated)
        {
            Id = id;
            Name = name;
            DisplayOrder = displayOrder;
            TimeCreated = timeCreated;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime TimeCreated { get; set; }

    }
}
