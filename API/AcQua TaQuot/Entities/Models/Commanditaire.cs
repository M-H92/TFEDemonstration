using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Commanditaire
    {
        [Column("CommanditaireId")]
        public Guid Id { get; set; }
        [Required()]
        public string Nom { get; set; }

        [ForeignKey(nameof(Statut))]
        public Guid? StatutId { get; set; }

        public ICollection<Prix>? Prices { get; set; }
        public ICollection<Application>? Applications { get; set; }
    }
}
