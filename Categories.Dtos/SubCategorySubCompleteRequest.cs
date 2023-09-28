using System.ComponentModel.DataAnnotations;

namespace Categories.Dtos
{
    public class SubCategorySubCompleteRequest: SubCategoriesRequest
    {
        [Required]
        public int id { get; set; }
    }
}
