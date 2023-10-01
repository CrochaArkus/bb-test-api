using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities.Entities
{
    public class ImageUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_image_Upload { get; set; }
        public int? idInteriorSubcategories { get; set; }
        public int? idSubcategories { get; set; }
        [Required]        
        public int idCategories { get; set; }
        [Required]
        public byte[] image_Data { get; set; }        
        [Required]
        public string name { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public DateTime create_date { get; set; }
        public DateTime? update_date { get; set; }
       
    }
}
