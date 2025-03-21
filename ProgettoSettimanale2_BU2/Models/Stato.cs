using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.Models
{
    public class Stato
    {
        [Key]
        public int StatoId { get; set; }
        public string? Nome { get; set; }
        public ICollection<Prenotazione> Prenotazioni { get; set; }
    }
}
