using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class LigneFacture
    {
        [Column("LigneFactureId")]
        public Guid Id { get; set; }
        [Required()]
        public int MoisFacturation { get; set; }
        [Required()]
        public decimal PrixUnitaire { get; set; }
        [Required()]
        public decimal Quantite { get; set; }

        [ForeignKey(nameof(Prestation))]
        public Guid PrestationId { get; set; }
        public Prestation? Prestation { get; set; }
    }
}
