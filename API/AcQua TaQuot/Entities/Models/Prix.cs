using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Prix
    {
        [Column("PrixId")]
        public Guid Id { get; set; }
        [Required()]
        public DateTime DateDebut { get; set; }
        [Required()]
        public decimal Valeur { get; set; }
        [Required()]
        public decimal TauxTVA { get; set; }


        [ForeignKey(nameof(Commanditaire))]
        public Guid CommanditaireId { get; set; }
        public Commanditaire? Commanditaire { get; set; }
    }
}
