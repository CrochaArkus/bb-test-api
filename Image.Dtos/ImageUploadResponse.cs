namespace Image.Dtos
{
    public class ImageUploadResponse
    {
        public int idImage { get; set; }     
        public int? idInteriorSubcategories { get; set; }
        public int? idSubcategories { get; set; }       
        public int? idCategories { get; set; }        
        public string imageFile { get; set; }
        public bool active { get; set; }       
        
    }
}
