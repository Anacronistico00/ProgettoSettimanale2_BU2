using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Camera> Camere { get; set; }
    }
}
