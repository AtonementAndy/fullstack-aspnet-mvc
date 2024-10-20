using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeeEngineering.Models
{
    public class CandidateModel
    {
        public CandidateModel()
        {
            IsActive = true;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } = default!;

        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        public string Name { get; private set; } = string.Empty;

        [Required(ErrorMessage = "The field Surname is required")]
        [StringLength(100)]
        public string Surname { get; private set; } = string.Empty;

        [Required(ErrorMessage = "The field Country is required")]
        [StringLength(50)]
        public string Country { get; private set; } = string.Empty;

        public bool IsActive { get; set; }
        
    }
}
