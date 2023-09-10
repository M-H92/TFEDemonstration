using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.userPreferences
{
    public class PreferenceEncodagePrestation
    {

        [Column("PreferenceEncodagePrestationId")]
        public Guid Id { get; set; }
        [MaxLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [MinLength(3, ErrorMessage = "Trigramme utilisateur uniquement")]
        [Required()]
        public string Utilisateur { get; set; }
        [Required()]
        public bool ResetTypeTache { get; set; }
        [Required()]
        public bool ResetCommanditaire { get; set; }
        [Required()]
        public bool ResetApplication { get; set; }
        [Required()]
        public bool ResetModule { get; set; }
        [Required()]
        public bool InitAtLastDate { get; set; }
        [Required()]
        public bool TempsAsInputTypeTime { get; set; }
    }
}
