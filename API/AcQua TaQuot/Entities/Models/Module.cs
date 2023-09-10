using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Module
    {
        [Column("ModuleId")]
        public Guid Id { get; set; }
        [Required()]
        public string Libelle { get; set; }


        [ForeignKey(nameof(Application))]
        public Guid ApplicationId { get; set; }

        [ForeignKey(nameof(Statut))]
        public Guid? StatutId { get; set; }


        public Application? Application { get; set; }
        public ICollection<Tache>? Taches { get; set; }
    }
}
