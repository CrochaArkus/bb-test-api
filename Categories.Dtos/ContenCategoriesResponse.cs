namespace Categories.Dtos
{
    public class ContenCategoriesResponse
    {
        public int IdCategory { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public List<ContentSubcategoriesResponse> contentSubcategoriesResponse { get; set; } 
        
    }
}
