using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Statut
    {
        [Column("StatutId")]
        public Guid Id { get; set; }
        [Required()]
        public string Libelle { get; set; }

        public ICollection<Prestation> Prestations { get; set; }
    }
}
