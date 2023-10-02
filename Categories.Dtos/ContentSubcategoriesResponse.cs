namespace Categories.Dtos
{
    public class ContentSubcategoriesResponse
    {
        public int idSubcategories { get; set; }        
        public string name { get; set; }
        public bool acvive { get; set; }
        public List<InteriorSubCategoriesResponse> interiorSubCategoriesResponse { get; set; }
    }
}
