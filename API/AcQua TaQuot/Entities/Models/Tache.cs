using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Tache
    {
        [Column("TacheId")]
        public Guid Id { get; set; }
        [Required()]
        public string Libelle { get; set; }


        [ForeignKey(nameof(Module))]
        public Guid ModuleId { get; set; }
        public Module? Module { get; set; }


        [ForeignKey(nameof(Prestation))]
        public Guid PrestationId { get; set; }
        public Prestation? Prestation { get; set; }
    }
}
