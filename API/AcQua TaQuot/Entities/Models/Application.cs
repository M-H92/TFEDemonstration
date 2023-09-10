using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Application
    {
        [Column("ApplicationId")]
        public Guid Id { get; set; }
        [Required()]
        public string Libelle { get; set; }

        [ForeignKey(nameof(Statut))]
        public Guid? StatutId { get; set; }


        [ForeignKey(nameof(Commanditaire))]
        public Guid CommanditaireId { get; set; }
        public Commanditaire? Commanditaire { get; set; }
        public ICollection<Module>? Modules { get; set; }
    }
}
