namespace Image.Dtos
{
    public class ImageRequest
    {
        public int interiorSubCategoryId { get; set; }
        public int subCategoryId { get; set; }
        public int categoryId { get; set; }
        public string image { get; set; }
        public string nameImage { get; set; }        

    }
}