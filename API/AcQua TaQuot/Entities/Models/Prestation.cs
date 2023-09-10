using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Prestation
    {
        [Column("PrestationId")]
        public Guid Id { get; set; }
        public int IssueGitLab { get; set; }
        public int? DisplayNumber { get; set; }
        public string? Commentaire { get; set; }
        [Required()]
        public DateTime Date { get; set; }
        [Required()]
        public int Temps { get; set; }
        public bool IsFacturable { get; set; }
        [MaxLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [MinLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [Required()]
        public string Utilisateur { get; set; }

        [ForeignKey(nameof(TypeTache))]
        public Guid TypeTacheId { get; set; }
        public TypeTache? TypeTache { get; set; }

        [ForeignKey(nameof(Statut))]
        public Guid StatutId { get; set; }
        public Statut? Statut { get; set; }

        public Tache? Tache { get; set; }
        public DateTime? DateFacturation { get; set; } = null;
        public ICollection<LigneFacture>? LignesFacture { get; set; }
    }
}
