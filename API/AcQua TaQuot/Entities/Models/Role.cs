using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Role
    {
        [Column("RoleId")]
        [Key]
        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<RoleUtilisateur>? Utilisateurs { get; set; }
    }
}
