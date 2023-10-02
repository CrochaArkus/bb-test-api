using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities.Entities
{
    public class SubCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_subcategories { get; set; }
        [Required]       
        public int id_categories { get; set; }
        [Required]        
        public string name { get; set; }        
        public string urlSubcategory { get; set; } = string.Empty;
        [Required]
        public bool active { get; set; }
        [Required]
        public DateTime create_date { get; set; }        
        public DateTime update_date { get; set; }

        [ForeignKey("id_categories")]
        public virtual Categories Categories { get; set; }
    }
}
