using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities.Entities
{
    public class Content
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_content { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int id_category { get; set; }
        [Required]
        public int id_subcategory { get; set; }
        [Required]
        public int id_interior_subcategory { get; set; }
        [Required]
        public int display { get; set; } 
        [Required]
        public bool active { get; set; }
        [Required]
        public bool unLocked { get; set; }
        [Required]
        public bool delete { get; set; }
        [Required]
        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public DateTime date_delete { get; set; }
    }    
}
