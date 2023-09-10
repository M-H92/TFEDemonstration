using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class RoleUtilisateur
    {
        [ForeignKey(nameof(Role))]
        [Required()]
        public string RoleId { get; set; }

        [MaxLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [MinLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [Required()]
        public string Utilisateur { get; set; }

    }
}
