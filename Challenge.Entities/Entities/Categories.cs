using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Entities.Entities
{
 
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_categories { get; set; }
        [Required]        
        public string name { get; set; }
        [Required]        
        public bool active { get; set; }
        [Required]        
        public DateTime create_date { get; set; }        
        [Column("update_date")]
        public DateTime update_date { get; set; }

    }
}
