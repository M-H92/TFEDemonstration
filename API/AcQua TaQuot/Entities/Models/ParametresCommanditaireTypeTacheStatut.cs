using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ParametresCommanditaireTypeTacheStatut
    {
        [Required()]
        [ForeignKey(nameof(Models.Commanditaire))]
        public Guid CommanditaireId { get; set; }
        [Required()]
        [ForeignKey(nameof(Models.TypeTache))]
        public Guid TypeTacheId { get; set; }
        [Required()]
        [ForeignKey(nameof(Models.Statut))]
        public Guid StatutId { get; set; }

        public Commanditaire Commanditaire { get; set; }
        public TypeTache TypeTache { get; set; }
        public Statut Statut { get; set; }
    }
}
