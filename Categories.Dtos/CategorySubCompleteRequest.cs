using System.ComponentModel.DataAnnotations;

namespace Categories.Dtos
{
    public class CategorySubCompleteRequest: CategoriesRequest
    {
        [Required]
        public int id { get; set; }
    }
}
