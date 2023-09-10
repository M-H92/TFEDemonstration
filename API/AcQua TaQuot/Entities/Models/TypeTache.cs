using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TypeTache
    {
        [Column("TypeTacheId")]
        public Guid Id { get; set; }
        [Required()]
        public string Libelle { get; set; }

        [ForeignKey(nameof(Statut))]
        public Guid? StatutId { get; set; }

        public ICollection<Prestation>? Prestations { get; set; }
    }
}
