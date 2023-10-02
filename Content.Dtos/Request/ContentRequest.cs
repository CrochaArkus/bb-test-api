using System.ComponentModel.DataAnnotations;

namespace Content.Dtos.Request
{
    public class ContentRequest
    {
        [Required]
        public string title { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public bool unLocked { get; set; }
        [Required]
        public List<ListCategories> listCategories { get; set; } 
    }
}
