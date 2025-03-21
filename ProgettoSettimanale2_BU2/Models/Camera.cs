using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale2_BU2.Models
{
    public class Camera
    {
        [Key]
        public Guid CameraId { get; set; }

        [Required(ErrorMessage = "Il numero della camera è obbligatorio")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Il tipo di camera è obbligatorio")]
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [Range(0, 10000, ErrorMessage = "Il prezzo deve essere compreso tra 0 e 10000")]
        public decimal Prezzo { get; set; }
        
        public bool Disponibile { get; set; } = true;
        public ICollection<Prenotazione> Prenotazioni { get; set; }
    }
}
