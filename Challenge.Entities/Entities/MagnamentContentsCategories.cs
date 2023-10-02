using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities.Entities
{
    public class MagnamentContentsCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_magnament_content_categories { get; set; }
        public int id_content { get; set; }
        public int id_categories { get; set; }
        public int id_subcategories { get; set; }
        public int id_interior_subcategories { get; set; }
    }
}
