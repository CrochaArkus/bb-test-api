namespace Content.Dtos.Request
{
    public class ManageContentResponse
    {
        public int id_content { get; set; }
        public string title { get; set; }
        public string category_name { get; set; }
        public int id_category { get; set; }
        public string Display { get; set; }
        public bool active { get; set; }
        public bool unlocked { get; set; }
        public int id_subCategory { get; set; }
        public int id_interior_subCategory { get; set; }
    }
}
