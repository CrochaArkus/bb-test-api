using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Entities.Entities
{
    public class InteriorSubcategoriesCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_interior_subcategory { get; set; }
        [Required]
        public int id_catgeory { get; set; }
        [Required]
        public int id_subcategory { get; set; }
        [Required]
        public string name { get; set; }
        public string url_interior_Subcategory { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
