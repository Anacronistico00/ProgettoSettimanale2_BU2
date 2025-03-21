using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.ViewModels
{
    public class EditPrenotazioneViewModel
    {
        [Key]
        public Guid PrenotazioneId { get; set; }

        [Required(ErrorMessage = "Il cliente è obbligatorio")]
        public required Guid ClienteId { get; set; }

        [Required(ErrorMessage = "La camera è obbligatoria")]
        public required Guid CameraId { get; set; }

        [Required(ErrorMessage = "La data di inizio è obbligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Data di inizio")]
        public required DateTime DataInizio { get; set; }

        [Required(ErrorMessage = "La data di fine è obbligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Data di fine")]
        public required DateTime DataFine { get; set; }

        [Required(ErrorMessage = "Lo stato è obbligatorio")]
        [StringLength(20)]
        public required string Stato { get; set; }
    }
}
