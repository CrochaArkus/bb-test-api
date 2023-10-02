using System.ComponentModel.DataAnnotations;

namespace Content.Dtos.Request
{
    public class ListCategories
    {
        [Required]
        public int id_interior_subcategory { get; set; }
        [Required]
        public int id_catgeory { get; set; }
        [Required]
        public int id_subcategory { get; set; }
    }
}
