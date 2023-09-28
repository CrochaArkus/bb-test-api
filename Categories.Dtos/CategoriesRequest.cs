using System.ComponentModel.DataAnnotations;

namespace Categories.Dtos
{
    public class CategoriesRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
