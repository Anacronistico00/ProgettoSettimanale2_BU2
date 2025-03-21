using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.ViewModels
{
    public class AddPrenotazioneViewModel
    {
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
        [StringLength(20)]
        public string Stato { get; set; }
    }
}
