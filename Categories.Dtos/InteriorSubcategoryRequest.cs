using System.ComponentModel.DataAnnotations;

namespace Categories.Dtos
{
    public class InteriorSubcategoryRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int categoryId { get; set; }
        [Required]
        public int subCategoryId { get; set; }
        public string? urlSubcategory { get; set; } = "";
    }
}
