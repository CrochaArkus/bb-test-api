using System.ComponentModel.DataAnnotations;

namespace Categories.Dtos
{
    public class SubCategoriesRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int categoryId { get; set; }
        
        public string? urlSubcategory { get; set; }
    }
}
