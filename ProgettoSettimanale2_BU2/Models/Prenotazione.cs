using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.Models
{
    public class Prenotazione
    {
        [Key]
        public Guid PrenotazioneId { get; set; }

        [Required(ErrorMessage = "Il cliente è obbligatorio")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "La camera è obbligatoria")]
        public Guid CameraId { get; set; }

        [Required(ErrorMessage = "La data di inizio è obbligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Data di inizio")]
        public DateTime DataInizio { get; set; }

        [Required(ErrorMessage = "La data di fine è obbligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Data di fine")]
        public DateTime DataFine { get; set; }

        [Required(ErrorMessage = "Lo stato è obbligatorio")]
        public int StatoId { get; set; }

        [ForeignKey("StatoId")]
        public Stato Stato { get; set; }

        public DateOnly CreatedAt { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("CameraId")]
        public Camera Camera { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
